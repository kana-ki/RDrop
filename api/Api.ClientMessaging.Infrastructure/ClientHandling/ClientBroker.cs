namespace RDrop.Api.ClientMessaging.Infrastructure.ClientHandling
{

    using System;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MessageHandling;
    using MessageHandling.Internal;

    public class ClientBroker
    {

        private WebSocket _webSocket;
        private CancellationTokenSource _cancellation;

        public event OnCloseDelegate OnClose;
        public delegate void OnCloseDelegate(ClientBroker socketHandler);

        public ClientBroker(WebSocket webSocket)
        {
            this._webSocket = webSocket;
        }

        public async Task ReceiveAsync()
        {
            this._cancellation = new CancellationTokenSource();
            while (this._webSocket.State == WebSocketState.Open)
            {
                ArraySegment<Byte> buffer = new ArraySegment<Byte>(new byte[1024]);
                WebSocketReceiveResult result = await this._webSocket.ReceiveAsync(buffer, this._cancellation.Token);
                if (result.EndOfMessage)
                {
                    String message = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    new MessageDispatcher(new MessageContext(this, message)).DispatchAsync();
                }
            }
        }

        public async Task SendAsync(String message)
        {
            ArraySegment<Byte> buffer = new ArraySegment<Byte>(Encoding.UTF8.GetBytes(message));
            await this._webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, this._cancellation.Token);
        }

        public async Task CloseAsync(String closeReason)
        {
            this._cancellation?.Cancel();
            CancellationTokenSource cancellation = new CancellationTokenSource();
            await this._webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, closeReason, cancellation.Token);
            this.OnClose.BeginInvoke(this, null, null);
        }

    }

}