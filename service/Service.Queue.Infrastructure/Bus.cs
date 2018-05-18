namespace RDrop.Service.Bus.Infrastructure
{

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Threading.Tasks;

    public class Bus
    {

        private static ChannelBroker _channels;

        public void Send<T>(T message)
        {
            var token = JToken.FromObject(message);
            token["_t"] = message.GetType().AssemblyQualifiedName;
            //this._queueHandlerFactory.GetOrAdd("chipppayQueue2").Publish(token.ToString(Formatting.None));
        }

        public Task SendAsync<T>(T message)
        {

            // Code here is Synchronous
            return Task.Run(() => this.Send(message));
            // Code here is async
        }

    }

}