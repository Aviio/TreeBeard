
using System;

namespace TreeBeard.Interfaces
{
    public interface IInput : IInitializable, IDisposable
    {
        string Type { get; set; }
        string Alias { get; set; }

        IObservable<Event> Execute();
    }
}
