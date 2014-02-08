
using System;

namespace TreeBeard.Interfaces
{
    public interface IInput : IInitializable
    {
        void SetSource(string source);
        IObservable<IEvent> Execute();
    }
}
