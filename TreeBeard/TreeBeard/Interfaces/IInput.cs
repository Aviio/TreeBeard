
using System;

namespace TreeBeard.Interfaces
{
    public interface IInput : IInitializable
    {
        IObservable<IEvent> Execute();
    }
}
