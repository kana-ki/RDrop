namespace RDrop.Api.ClientMessaging.Infrastructure.ClientHandling
{

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Net.WebSockets;

    public static class ClientPool
    {

        private static List<ClientBroker> _clientBrokers;

        static ClientPool()
        {
            _clientBrokers = new List<ClientBroker>();
        }

        internal static ClientBroker RegisterWebSocket(WebSocket clientSocket)
        {
            ClientBroker clientBroker = new ClientBroker(clientSocket);
            clientBroker.OnClose += (handler) => _clientBrokers.Remove(handler);
            _clientBrokers.Add(clientBroker);
            return clientBroker;
        }

        public static async Task BroadcastAsync(String message) =>
            await Task.Run(() => _clientBrokers.AsParallel().ForAll(handler => handler.SendAsync(message)));

        public static async Task CloseAllAsync(String message) =>
            await Task.Run(() => _clientBrokers.AsParallel().ForAll(handler => handler.CloseAsync(message)));

    }

}