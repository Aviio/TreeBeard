
using System;

namespace TreeBeard.Interfaces
{
    public interface IFilter : IInitializable, IDisposable
    {
        Func<Event, bool> Predicate { get; set; }

        Event Execute(Event value);
    }
}
