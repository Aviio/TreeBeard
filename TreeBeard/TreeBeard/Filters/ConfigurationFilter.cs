using System;
using TreeBeard.Events;
using TreeBeard.Extensions;
using TreeBeard.Interfaces;
using TreeBeard.Utils;

namespace TreeBeard.Filters
{
    public class ConfigurationFilter : AbstractFilter
    {
        private IFilter _filter;

        public override Func<Event, bool> Predicate
        {
            get { 
                return (_filter != null) ? _filter.Predicate : null; 
            }
            set { }
        }

        public override Event Execute(Event value)
        {
            return _filter.Execute(value);
        }

        public override void Initialize(params string[] args)
        {
            _filter = ScriptUtils.ConstructFilter(args[0], args[1], args.SubArray(2));
        }
    }
}
