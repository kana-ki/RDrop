namespace RDrop.Service.Bus.Infrastructure
{

    using System;
    using System.Text;
    using System.Threading;
    using RabbitMQ.Client;
    using RDrop.Service.Bus.Infrastructure.Enumerations;

    internal class ChannelBroker
    {

        public bool IsListening => this._thread.ThreadState.HasFlag(ThreadState.Running);

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly String _queueName;
        private readonly Int32 _pollTime;
        private Thread _thread;

        public ChannelBroker(Uri amqpUri, String queueName, Int32 pollTime)
        {
            var connectionFactory = new ConnectionFactory {
                Uri = amqpUri
            };
            this._connection = connectionFactory.CreateConnection();
            this._channel = this._connection.CreateModel();
            this._queueName = queueName;
            this._pollTime = pollTime;
            this.EnsureQueue();
        }

        private void EnsureQueue()
        {
            this._channel.QueueDeclare(this._queueName, false, false, false, null);
        }

        public void Publish(string message)
        {
            var data = Encoding.UTF8.GetBytes(message);
            var exchangeName = "";
            this._channel.BasicPublish(exchangeName, this._queueName, null, data);
        }

        private string Get(out ulong deliveryTag)
        {
            deliveryTag = 0;

            var data = this._channel.BasicGet(this._queueName, false);

            if (data == null) {
                return null;
            }

            var message = Encoding.UTF8.GetString(data.Body);

            deliveryTag = data.DeliveryTag;

            return message;
        }

        public void Complete(ulong deliveryTag)
        {
            this._channel.BasicAck(deliveryTag, false);
        }

        ~ChannelBroker()
        {
            this._channel.Dispose();
            this._connection.Dispose();
        }

        public void Listen()
        {
            while (true) {
                ulong deliveryTag;
                var message = this.Get(out deliveryTag);
                if (message == null) {
                    Thread.Sleep(this._pollTime);
                    continue;
                }
                new MessageDispatcher(message).HandleAsync(status => {
                    if (status == HandleStatus.Successful || status == HandleStatus.Invalid) {
                        this.Complete(deliveryTag);
                    }
                });
            }
        }

        public Thread ListenAsync()
        {
            this._thread = new Thread(() => {
                try {
                    this.Listen();
                } catch (Exception e) {
                    Console.Error.WriteLineAsync(e.ToString());
                }
            });
            this._thread.Start();
            return this._thread;
        }

    }
    
}