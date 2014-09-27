using System;
using TreeBeard.ExtensionMethods;
using TreeBeard.Interfaces;
using TreeBeard.Utils;

namespace TreeBeard.Filters
{
    public class ConfigurationFilter : AbstractFilter
    {
        private IFilter _filter;

        public override Func<IEvent, bool> Predicate
        {
            get { 
                return (_filter != null) ? _filter.Predicate : null; 
            }
            set { }
        }

        public override IEvent Execute(IEvent value)
        {
            return _filter.Execute(value);
        }

        public override void Initialize(params string[] args)
        {
            _filter = ScriptUtils.ConstructFilter(args[0], args[1], args.SubArray(2));
        }
    }
}
