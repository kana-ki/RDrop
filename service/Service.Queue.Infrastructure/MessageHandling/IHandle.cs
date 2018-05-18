namespace RDrop.Service.Bus.Infrastructure.MessageHandling {

    public interface IHandle<T> {
        HandleStatus Handle(T message);
    }

}