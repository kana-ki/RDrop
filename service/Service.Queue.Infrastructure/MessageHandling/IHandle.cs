using RDrop.Service.Bus.Infrastructure.Enumerations;

namespace RDrop.Service.Bus.Infrastructure.Interfaces {

    public interface IHandle<in T> {
        HandleStatus Handle(T message);
    }

}