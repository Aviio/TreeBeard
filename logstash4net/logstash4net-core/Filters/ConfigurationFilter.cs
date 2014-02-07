using System;
using logstash4net.Events;
using logstash4net.ExtensionMethods;
using logstash4net.Utils;
using logstash4net.Interfaces;

namespace logstash4net.Filters
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
