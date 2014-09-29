using System;
using TreeBeard.Interfaces;

namespace TreeBeard.Filters
{
    public abstract class AbstractFilter : IFilter
    {
        public virtual Func<Event, bool> Predicate { get; set; }

        public abstract Event Execute(Event value);
        public abstract void Initialize(params string[] args);

        public virtual void Dispose() { }
    }
}
