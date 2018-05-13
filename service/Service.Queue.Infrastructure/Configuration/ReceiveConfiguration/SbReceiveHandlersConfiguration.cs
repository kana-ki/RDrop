namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveConfiguration
{

    public class SbReceiveHandlersConfiguration : SbReceiveHandlersConfigurationContext
    {

        public SbReceiveHandlersConfiguration(SbReceiveConfigurationContext receiveConfiguration, SbConfiguration serviceBusConfiguration, ServiceBus serviceBus)
            : base(receiveConfiguration, serviceBusConfiguration, serviceBus)
        {
        }

    }

}
