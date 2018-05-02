namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveCnnfiguration
{

    using System;

    public abstract class SbReceiveExchangeConfigurationContext : SbReceiveEndpointConfigurationContext
    {

        protected readonly SbReceiveEndpointConfiguration _sbReceiveEndpointConfiguration;

        public SbReceiveExchangeConfigurationContext(SbReceiveEndpointConfiguration sbReceiveEndpointConfiguration, SbReceiveConfiguration sbReceiveConfiguration, SbConfiguration serviceBusConfiguration, ServiceBus serviceBus)
            : base(sbReceiveConfiguration, serviceBusConfiguration, serviceBus) =>
            this._sbReceiveEndpointConfiguration = sbReceiveEndpointConfiguration;

        public override SbReceiveExchangeConfiguration FromExchange(String exchange) =>
            this._sbReceiveEndpointConfiguration.FromExchange(exchange);

        public abstract SbReceiveExchangeConfiguration WithChannelName(String channelName);

        public abstract SbReceiveExchangeConfiguration WithPollInterval(Int32 intervalInMilliseconds);

    }

}
