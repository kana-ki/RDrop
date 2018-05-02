namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveCnnfiguration
{

    using System;
    using System.Reflection;

    public abstract class SbReceiveConfigurationContext : SbConfigurationContext
    {

        protected readonly SbConfiguration _serviceBusConfiguration;

        public SbReceiveConfigurationContext(SbConfiguration serviceBusConfiguration, ServiceBus serviceBus) : base(serviceBus)
        {
            this._serviceBusConfiguration = serviceBusConfiguration;
        }

        public abstract SbReceiveEndpointConfiguration FromAmqpEndpoint(String amqpUri);

        public abstract SbReceiveConfiguration WithHandlersIn(Assembly assembly);

    }

}
