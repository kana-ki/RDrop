namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveCnnfiguration
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

        public override SbReceiveConfiguration WithHandlersIn(Assembly assembly) =>
            this._sbReceiveConfiguration.WithHandlersIn(assembly);

        public abstract SbReceiveExchangeConfiguration FromExchange(String exchange);

    }

}
