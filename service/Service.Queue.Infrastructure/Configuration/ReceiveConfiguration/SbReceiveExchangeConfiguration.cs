namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveConfiguration
{

    using System;

    public class SbReceiveExchangeConfiguration : SbReceiveExchangeConfigurationContext
    {

        internal String ExchangeName { get; set; }
        internal String ChannelName { get; set; }
        internal Int32 IntervalInMilliseconds { get; set; }

        internal SbReceiveExchangeConfiguration(String exchangeName, SbReceiveEndpointConfiguration sbReceiveEndpointConfiguration, SbReceiveConfiguration sbReceiveConfiguration, SbConfiguration serviceBusConfiguration, ServiceBus serviceBus)
            : base(sbReceiveEndpointConfiguration, sbReceiveConfiguration, serviceBusConfiguration, serviceBus)
        {
            this.ExchangeName = exchangeName;
            this.ChannelName = null;
            this.IntervalInMilliseconds = 30;
        }

        public override SbReceiveExchangeConfiguration WithChannelName(String channelName)
        {
            this.ChannelName = channelName;
            return this;
        }

        public override SbReceiveExchangeConfiguration WithPollInterval(Int32 intervalInMilliseconds)
        {
            if (intervalInMilliseconds > 10)
            {
                this.IntervalInMilliseconds = intervalInMilliseconds;
            }
            return this;
        }

    }

}
