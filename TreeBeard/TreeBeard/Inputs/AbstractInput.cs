using System;
using TreeBeard.Interfaces;

namespace TreeBeard.Inputs
{
    public abstract class AbstractInput : IInput
    {
        public abstract IObservable<IEvent> Execute();
        public abstract void Initialize(params string[] args);

        public string Source { get; set; }
    }
}
