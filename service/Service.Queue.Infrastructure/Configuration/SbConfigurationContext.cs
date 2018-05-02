namespace RDrop.Service.Bus.Infrastructure.Configuration
{

    public abstract class SbConfigurationContext
    {

        protected readonly ServiceBus _serviceBus;

        internal SbConfigurationContext(ServiceBus serviceBus)
        {
            this._serviceBus = serviceBus;
        }

        public void ListenAsync()
        {
            this._serviceBus.ListenAsync();
        }

    }

}