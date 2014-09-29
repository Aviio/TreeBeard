
using System;

namespace TreeBeard.Interfaces
{
    public interface IFilter : IInitializable
    {
        Func<Event, bool> Predicate { get; set; }

        Event Execute(Event value);
    }
}
