namespace RDrop.Service
{
    
    using RDrop.Service.Bus.Handlers;
    using RDrop.Service.Bus.Infrastructure;

    class Program
    {

        static void Main(string[] args) 
        {


            ServiceBus
                .CreateAndConfigure()
                    .Receive()
                        .FromAmqpEndpoint("ampq://localhost:15672")
                            .FromExchange("DownloadExchange")
                                .WithChannelName("downloadWorker1")
                                .WithPollInterval(30)
                            .FromExchange("DownloadExchange2")
                                .WithChannelName("downloadWorker1")
                                .WithPollInterval(30)
                        .WithHandlersIn(typeof(StartDownloadHandler).Assembly)
                    .Send()
                        .MessagesInNamespace("Service.Bus.Messages.Broadcasts")
                            .ToAmqpEndpoint("ampq://localhost:15672")
                            .ToExchange("FanoutExchange", ExchangeType.FanOut)
                        .MessagesInNamespace("Service.Bus.Messages")
                            .ToAmqpEndpoint("ampq://localhost:15672")
                            .ToExchange("NormalExchange")
                        .MessagesInNamespace("Service.Bus.Messages.Direct")
                            .ToAmqpEndpoint("ampq://localhost:15672")
                            .ToChannel("DirectChannel", createChannel: false)
                .ListenAsync();
            
        }

    }

}