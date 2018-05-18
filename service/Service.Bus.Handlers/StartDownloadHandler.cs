namespace RDrop.Service.Bus.Handlers
{

    using RDrop.Service.Bus.Infrastructure.MessageHandling;
    using System;

    public class StartDownloadHandler : IHandle<StartDownload>
    {
        public HandleStatus Handle(StartDownload message)
        {
            throw new NotImplementedException();
        }
    }

    public class StartDownload : ICommand
    {

    }

}
