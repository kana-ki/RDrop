using System;
using System.Collections.Generic;
using System.Reflection;
using RDrop.Service.Bus.Infrastructure.MessageHandling;

namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveConfiguration
{

    public class SbReceiveHandlersConfiguration : SbReceiveHandlersConfigurationContext
    {

        internal Dictionary<Type, List<Type>> HandlerMap;
        internal Dictionary<Type, List<Delegate>> InlineHandlerMap; // Make a polymorphic wrapper for these two

        public SbReceiveHandlersConfiguration(SbReceiveConfigurationContext receiveConfiguration, SbConfiguration serviceBusConfiguration, ServiceBus serviceBus)
            : base(receiveConfiguration, serviceBusConfiguration, serviceBus)
        {
        }

        public override SbReceiveHandlersConfiguration Handler<H>()
        {
            //throw new System.NotImplementedException();
            return this;
        }

        public override SbReceiveHandlersConfiguration Handler<C>(Func<C, HandleStatus> handler)
        {
            var messageType = typeof(C);
            if (this.InlineHandlerMap.ContainsKey(messageType))
            {
                this.InlineHandlerMap[messageType].Add(handler);
            }
            else
            {
                this.InlineHandlerMap.Add(messageType, new List<Delegate> { handler });
            }
            return this;
        }

        public override SbReceiveHandlersConfiguration HandlersInAssembly(Assembly assembly)
        {
            //throw new System.NotImplementedException();
            return this;
        }
    }

}
