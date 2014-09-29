
using System;

namespace TreeBeard.Interfaces
{
    public interface IInput : IInitializable, IDisposable
    {
        string Type { get; set; }
        string Id { get; set; }

        IObservable<Event> Execute();
    }
}
