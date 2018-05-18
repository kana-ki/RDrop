namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveConfiguration
{

    using RDrop.Service.Bus.Infrastructure.MessageHandling;
    using System;
    using System.Reflection;

    public abstract class SbReceiveHandlersConfigurationContext : SbReceiveConfigurationContext
    {

        private readonly SbReceiveConfigurationContext _receiveConfiguration;

        public SbReceiveHandlersConfigurationContext(SbReceiveConfigurationContext receiveConfiguration, SbConfiguration serviceBusConfiguration, ServiceBus serviceBus)
            : base(serviceBusConfiguration, serviceBus)
        {
            this._receiveConfiguration = receiveConfiguration;
        }

        public override SbReceiveEndpointConfiguration FromAmqpEndpoint(string amqpUri)
        {
            return this.FromAmqpEndpoint(amqpUri);
        }

        public override SbReceiveHandlersConfiguration HandledBy()
        {
            return this._receiveConfiguration.HandledBy();
        }

        public abstract SbReceiveHandlersConfiguration HandlersInAssembly(Assembly assembly);

        public abstract SbReceiveHandlersConfiguration Handler<H>() where H : class;

        public abstract SbReceiveHandlersConfiguration Handler<C>(Func<C, HandleStatus> handler);

    }

}
