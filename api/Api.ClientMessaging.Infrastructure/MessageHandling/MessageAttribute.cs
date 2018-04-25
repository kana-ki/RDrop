namespace RDrop.Api.ClientMessaging.Infrastructure.MessageHandling
{

    using System;

    public sealed class MessageAttribute : Attribute
    {

        public readonly string[] Keys;

        public MessageAttribute(params string[] keys)
        {
            this.Keys = keys;
        }

    }

}