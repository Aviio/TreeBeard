using System;
using TreeBeard.Events;
using TreeBeard.ExtensionMethods;
using TreeBeard.Utils;
using TreeBeard.Interfaces;

namespace TreeBeard.Filters
{
    internal class ConfigurationFilter :IFilter
    {
        private IFilter _filter;

        public IEvent Execute(IEvent value)
        {
            return _filter.Execute(value);
        }

        public void Initialize(params string[] args)
        {
            _filter = ScriptUtils.ConstructFilter(args[0], args.SubArray(1));
        }
    }
}
