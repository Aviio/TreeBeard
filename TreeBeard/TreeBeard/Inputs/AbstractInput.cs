using System;
using TreeBeard.Interfaces;

namespace TreeBeard.Inputs
{
    public abstract class AbstractInput : IInput
    {
        public abstract IObservable<Event> Execute();
        public abstract void Initialize(params string[] args);

        public virtual string Type { get; set; }
        public virtual string Id { get; set; }
    }
}
