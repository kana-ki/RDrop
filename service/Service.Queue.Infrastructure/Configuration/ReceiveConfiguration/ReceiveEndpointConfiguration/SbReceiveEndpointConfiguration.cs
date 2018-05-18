namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveConfiguration
{

    using System;
    using System.Collections.Concurrent;

    public class SbReceiveEndpointConfiguration : SbReceiveEndpointConfigurationContext
    {

        internal Uri AmqpEndpoint;
        internal ConcurrentBag<SbReceiveExchangeConfiguration> Exchanges { get; set; }

        internal SbReceiveEndpointConfiguration(String amqpUri, SbReceiveConfiguration sbReceiveConfiguration, SbConfiguration serviceBusConfiguration, ServiceBus serviceBus)
            : base(sbReceiveConfiguration, serviceBusConfiguration, serviceBus)
        {
            this.AmqpEndpoint = new Uri(amqpUri);
        }

        public override SbReceiveExchangeConfiguration FromExchange(string exchange)
        {
            var exchangeConfig = new SbReceiveExchangeConfiguration(exchange, this, this._sbReceiveConfiguration, this._serviceBusConfiguration, this._serviceBus);
            this.Exchanges.Add(exchangeConfig);
            return exchangeConfig;
        }

    }

}