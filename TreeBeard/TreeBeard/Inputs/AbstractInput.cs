using System;
using TreeBeard.Interfaces;

namespace TreeBeard.Inputs
{
    public abstract class AbstractInput : IInput
    {
        public virtual string Type { get; set; }
        public virtual string Id { get; set; }

        public abstract IObservable<Event> Execute();
        public abstract void Initialize(params string[] args);

        public virtual void Dispose() { }
    }
}
