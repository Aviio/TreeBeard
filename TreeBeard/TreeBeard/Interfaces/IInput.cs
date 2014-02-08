
using System;

namespace TreeBeard.Interfaces
{
    public interface IInput : IInitializable
    {
        string Source { get; set; }

        IObservable<IEvent> Execute();
    }
}
