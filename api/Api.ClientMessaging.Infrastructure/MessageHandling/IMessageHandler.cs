namespace RDrop.Api.ClientMessaging.Infrastructure.MessageHandling
{

    using System.Threading.Tasks;

    public interface IMessageHandler<T>
    {

        Task Handle(T request);

    }
    
}