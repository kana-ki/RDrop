namespace RDrop.Service.Bus.Infrastructure
{

    using System;
    using System.Reflection;
    using System.Threading;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RDrop.Service.Bus.Infrastructure.Enumerations;

    public class MessageDispatcher
    {

        private Thread _thread;
        private readonly dynamic _message;

        public delegate void CompletionHandle(HandleStatus status);

        public MessageDispatcher(String message)
        {
            Type type = this.DetermineType(message);
            this._message = JsonConvert.DeserializeObject(message, type);
            if (this._message == null)
                throw new TypeLoadException("The type for this message is not supported.");
        }

        private Type DetermineType(String message)
        {
            String typeName = JsonConvert.DeserializeObject<JToken>(message)["_t"]?.Value<String>();
            if (String.IsNullOrWhiteSpace(typeName))
                throw new TypeLoadException("The type could not determined for the message.");
            Type type = null;
            try
            {
                type = Type.GetType(typeName);
            }
            catch (TypeLoadException) { }
            if (type == null)
                throw new TypeLoadException("The type could not be found for the message.");
            return type;
        }

        public HandleStatus Dispatch()
        {
            IEnumerable<Assembly> assemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies().
            //var handlers = this._kernel.GetAll(typeof(IHandle<>).MakeGenericType(this._message.GetType() as Type));
            //foreach (dynamic handler in handlers) {
            //    HandleStatus result = handler.Handle(this._message);
            //    if (result != HandleStatus.Successful) {
            //        return result;
            //    }
            //}
            //return HandleStatus.Successful;
        }

        public Thread HandleAsync(CompletionHandle completionHandle)
        {
            this._thread = new Thread(() =>
            {
                try
                {
                    var result = this.Dispatch();
                    completionHandle?.Invoke(result);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLineAsync(e.ToString());
                }
            });
            this._thread.Start();
            return this._thread;
        }

    }

}