using System;
using TreeBeard.Interfaces;
using TreeBeard.Utils;

namespace TreeBeard.Inputs
{
    public abstract class AbstractInput : IInput
    {
        public abstract IObservable<IEvent> Execute();
        public abstract void Initialize(params string[] args);

        public virtual string Type { get; set; }
        public virtual string Id { get; set; }
    }
}
