using System;
using TreeBeard.Interfaces;

namespace TreeBeard.Inputs
{
    public abstract class AbstractInput : IInput
    {
        public abstract IObservable<IEvent> Execute();
        public abstract void Initialize(params string[] args);

        protected string Source { get; private set; }

        public void SetSource(string source)
        {
            Source = source;
        }
    }
}
