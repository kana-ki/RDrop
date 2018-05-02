namespace RDrop.Api.ClientMessaging.Infrastructure
{
    
    using System.Reflection;
    using System.Net.WebSockets;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using ClientHandling;
    using MessageHandling;
    using MessageHandling.Internal;

    public static class ClientMessagingConfiguration
    {

        public static void UseWebSocketMessaging(this IApplicationBuilder appBuilder, Assembly handlerDefinitionsAssembly, Assembly messageDefinitionsAssembly)
        {
            MessageDispatcher.LoadMessageHandleMap(handlerDefinitionsAssembly, messageDefinitionsAssembly);
            appBuilder.UseWebSockets();
            appBuilder.Use(async (context, next) => {
                if (!context.Request.Path.StartsWithSegments(new PathString("/ws")))
                {
                    await next();
                    return;
                }
                if (context.WebSockets.IsWebSocketRequest)
                {
                    WebSocket socket = await context.WebSockets.AcceptWebSocketAsync();
                    ClientBroker socketHandler = ClientPool.RegisterWebSocket(socket);
                    var sockerReceiveTask = socketHandler.ReceiveAsync();
                    socketHandler.SendAsync("You've successfully connected.");
                    ClientPool.BroadcastAsync($"{context.Connection.RemoteIpAddress} successfully connected.");
                    await sockerReceiveTask;
                }
                else
                {
                    context.Response.StatusCode = 426;
                    context.Response.Headers.Add("Upgrade", "websocket");
                }
            });
        }

    }
    
}