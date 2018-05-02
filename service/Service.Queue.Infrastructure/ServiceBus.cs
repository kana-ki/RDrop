namespace RDrop.Service.Bus.Infrastructure
{

    using RDrop.Service.Bus.Infrastructure.Configuration;
    using System.Collections.Concurrent;
    using System.Linq;

    public class ServiceBus
    {

        private ConcurrentDictionary<string, ChannelBroker> _queueHandlers { get; set; }
        private SbConfiguration _configuration;

        public static SbConfiguration CreateAndConfigure()
        {
            return new ServiceBus().Configure();
        }

        private SbConfiguration Configure()
        {
            this._configuration = new SbConfiguration(this);
            return this._configuration;
        }

        public void ListenAsync()
        {
            InitQueueHandlers();
            this._queueHandlers
                .Where(q => !q.Value.IsListening)
                .AsParallel().ForAll(q =>
                    _queueHandlers[q.Key].ListenAsync()
                );
        }

        private void InitQueueHandlers() =>
            this._configuration.Channels.AsParallel().ForAll(channelName =>
                _queueHandlers.TryAdd(channelName, new ChannelBroker(this._configuration.AmqpUri, channelName, this._configuration.QueuePollInterval))
            );

    }
}