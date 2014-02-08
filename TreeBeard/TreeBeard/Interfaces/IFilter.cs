
using System;

namespace TreeBeard.Interfaces
{
    public interface IFilter : IInitializable
    {
        Func<IEvent, bool> Predicate { get; set; }

        IEvent Execute(IEvent value);
    }
}
