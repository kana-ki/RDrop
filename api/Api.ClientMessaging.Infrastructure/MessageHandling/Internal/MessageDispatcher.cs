namespace RDrop.Api.ClientMessaging.Infrastructure.MessageHandling.Internal
{

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class MessageDispatcher
    {

        private static ConcurrentDictionary<String, (Type messageType, IEnumerable<Type> handlerTypes)> MessageHandleMap;

        private MessageContext _messageContext;

        public MessageDispatcher(MessageContext messageContext)
        {
            this._messageContext = messageContext;
        }

        public async Task DispatchAsync()
        {
            String messageKey;
            try
            {
                JToken messageToken;
                using (StringReader stringReader = new StringReader(this._messageContext.RawMessage))
                using (JsonTextReader jsonReader = new JsonTextReader(stringReader))
                    messageToken = await JToken.LoadAsync(jsonReader);
                messageKey = messageToken.Value<String>("_key");
            }
            catch (JsonReaderException e)
            {
                Console.Error.WriteLine($"Received unparsable input ({e.Message}):\n{this._messageContext.RawMessage}");
                return;
            }
            catch (InvalidCastException)
            {
                Console.Error.WriteLine($"Received unparsable key:\n{this._messageContext.RawMessage}");
                return;
            }

            if (!MessageHandleMap.ContainsKey(messageKey)) return;
            (Type messageType, IEnumerable<Type> handlerTypes) = MessageHandleMap[messageKey];
            dynamic message = JsonConvert.DeserializeObject(this._messageContext.RawMessage, messageType);
            handlerTypes.AsParallel().ForAll(handlerType =>
            {
                Object[] args = null;
                if (handlerType.GetConstructor(new [] { typeof(MessageContext) }) != null)
                {
                    args = new [] { this._messageContext };
                }
                else if (handlerType.GetConstructor(new Type[0]) != null)
                {
                    args = new Object[0];
                }
                dynamic handler = Activator.CreateInstance(handlerType, args: args);
                handler.Handle(message);
            });
        }

        public static void LoadMessageHandleMap(Assembly handlerDefinitionsAssembly, Assembly messageDefinitionsAssembly)
        {
            if (MessageHandleMap != null) return;
            var messageHandleMap = new ConcurrentDictionary<String, (Type messageType, IEnumerable<Type> handlerTypes)>();
            ParallelQuery<Type> handlerDefinitionsAssemblyTypes = handlerDefinitionsAssembly.GetTypes().AsParallel();
            ParallelQuery<Type> messageDefinitionsAssemblyTypes = messageDefinitionsAssembly.GetTypes().AsParallel();
            messageDefinitionsAssemblyTypes.ForAll(messageType =>
            {
                Object[] attributes = messageType.GetCustomAttributes(typeof(MessageAttribute), true);
                if (!attributes.Any()) return;
                IEnumerable<String> messageKeys = attributes.AsParallel().SelectMany(attr => (attr as MessageAttribute).Keys);
                if (!messageKeys.Any())
                {
                    messageKeys = new[]
                    {
                        messageType.Name,
                        new Regex("(Message|Command|Request)$").Replace(messageType.Name, String.Empty)
                    };
                }
                IEnumerable<Type> handlerTypes = handlerDefinitionsAssemblyTypes.Where(handlerType =>
                    handlerType.GetInterfaces().Any((inter) =>
                        inter.IsGenericType && inter.GetGenericTypeDefinition() == typeof(IMessageHandler<>)
                        && inter.GetGenericArguments().First() == messageType
                    )).ToList();
                messageKeys.AsParallel().ForAll(key =>
                    messageHandleMap.TryAdd(key, (messageType, handlerTypes)));
            });
            MessageHandleMap = messageHandleMap;
        }

    }

}
