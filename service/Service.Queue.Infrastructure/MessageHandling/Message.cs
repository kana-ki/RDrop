using System;

namespace RDrop.Service.Bus.Infrastructure.MessageHandling {

    public class Message<T> {

        public Type Type => typeof(T);

        public T Command { get; }

        public Message(T command) {
            this.Command = command;
        }

    }
}