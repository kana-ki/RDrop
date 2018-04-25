namespace RDrop.Api.ClientMessaging.Infrastructure.MessageHandling
{

    using System;
    using System.Net.WebSockets;
    using Microsoft.AspNetCore.Http;
    using ClientHandling;

    public class MessageContext
    {
        
        public readonly String RawMessage;
        public readonly ClientBroker ClientBroker;

        public MessageContext(ClientBroker clientBroker, String rawMessage)
        {
            this.ClientBroker = clientBroker;
            this.RawMessage = rawMessage;
        }

    }

}