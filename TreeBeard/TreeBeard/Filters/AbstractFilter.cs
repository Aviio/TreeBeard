using System;
using TreeBeard.Interfaces;

namespace TreeBeard.Filters
{
    public abstract class AbstractFilter : IFilter
    {
        public virtual Func<IEvent, bool> Predicate { get; set; }

        public abstract IEvent Execute(IEvent value);
        public abstract void Initialize(params string[] args);
    }
}
