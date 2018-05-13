namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveConfiguration
{

    using System;
    using System.Reflection;

    public abstract class SbReceiveEndpointConfigurationContext : SbReceiveConfigurationContext
    {

        protected readonly SbReceiveConfiguration _sbReceiveConfiguration;

        public SbReceiveEndpointConfigurationContext(SbReceiveConfiguration sbReceiveConfiguration, SbConfiguration serviceBusConfiguration, ServiceBus serviceBus)
            : base(serviceBusConfiguration, serviceBus) =>
            this._sbReceiveConfiguration = sbReceiveConfiguration;

        public override SbReceiveEndpointConfiguration FromAmqpEndpoint(string amqpUri) =>
            this._sbReceiveConfiguration.FromAmqpEndpoint(amqpUri);

        public override SbReceiveHandlersConfiguration HandledBy(Assembly assembly) =>
            this._sbReceiveConfiguration.HandledBy(assembly);

        public abstract SbReceiveExchangeConfiguration FromExchange(String exchange);

    }

}
