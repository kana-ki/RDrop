namespace RDrop.Api.ClientMessaging.Models
{

    using System;
    using RDrop.Api.ClientMessaging.Infrastructure.MessageHandling;

    [Message("AddDownload", "Download")]
    public class AddDownloadMessage
    {

        public String Url;

    }
}