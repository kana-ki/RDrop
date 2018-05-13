namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveConfiguration
{

    using RDrop.Service.Bus.Infrastructure.Interfaces;
    using System.Reflection;

    public abstract class SbReceiveHandlersConfigurationContext : SbReceiveConfigurationContext
    {

        public SbReceiveHandlersConfigurationContext(SbReceiveConfigurationContext receiveConfiguration, SbConfiguration serviceBusConfiguration, ServiceBus serviceBus)
            : base(serviceBusConfiguration, serviceBus)
        {
        }

        public abstract SbReceiveHandlersConfiguration HandlersInAssembly(Assembly assembly);

        public abstract SbReceiveHandlersConfiguration HandlersInAssembly<T>() where T: IHandle<T>;

    }

}
