namespace RDrop.Api.ClientMessaging.Handlers
{

    using RDrop.Api.ClientMessaging.Infrastructure.MessageHandling;
    using RDrop.Api.ClientMessaging.Models;
    using System.Threading.Tasks;
    using System;

    public class AddDownloadHandler : IMessageHandler<AddDownloadMessage>
    {

        public async Task Handle(AddDownloadMessage message)
        {
            Console.WriteLine("Received Add Download message");
        }

    }

}