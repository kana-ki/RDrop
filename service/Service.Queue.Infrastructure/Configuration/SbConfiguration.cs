namespace RDrop.Service.Bus.Infrastructure.Configuration
{

    using RDrop.Service.Bus.Infrastructure.Configuration.ReceiveConfiguration;

    public class SbConfiguration : SbConfigurationContext
    {

        internal SbConfiguration(ServiceBus serviceBus) : base(serviceBus)
        {
        }

        public SbReceiveConfiguration Receive()
        {
            return new SbReceiveConfiguration(this, this._serviceBus);
        }

    }

}
