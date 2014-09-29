
using System;

namespace TreeBeard.Interfaces
{
    public interface IInput : IInitializable
    {
        string Type { get; set; }
        string Id { get; set; }

        IObservable<Event> Execute();
    }
}
