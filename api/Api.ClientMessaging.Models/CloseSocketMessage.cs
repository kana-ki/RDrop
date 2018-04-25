namespace RDrop.Api.ClientMessaging.Models
{

    using System;
    using RDrop.Api.ClientMessaging.Infrastructure.MessageHandling;

    [Message("CloseSocket", "Close")]
    public class CloseSocketMessage { }
    
}