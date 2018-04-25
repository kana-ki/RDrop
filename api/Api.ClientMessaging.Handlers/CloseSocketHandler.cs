namespace RDrop.Api.ClientMessaging.Handlers
{

    using RDrop.Api.ClientMessaging.Infrastructure.MessageHandling;
    using RDrop.Api.ClientMessaging.Models;
    using System.Threading.Tasks;
    using System;

    public class CloseSocketHandler : IMessageHandler<CloseSocketMessage>
    {

        private MessageContext _context;

        public CloseSocketHandler(MessageContext context) 
        {
            this._context = context;
        }

        public async Task Handle(CloseSocketMessage message)
        {
            await this._context.ClientBroker.CloseAsync("Closure requested by client.");
            Console.WriteLine("Closing web socket to ");
        }

    }

}