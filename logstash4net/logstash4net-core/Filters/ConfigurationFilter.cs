using System;
using logstash4net.Events;
using logstash4net.Utils;

namespace logstash4net.Filters
{
    internal class ConfigurationFilter :IFilter
    {
        private readonly IFilter _filter;

        public ConfigurationFilter(params string[] args)
        {
            Type type = Type.GetType(args[0], true);
            object[] oArgs = new object[args.Length - 1];
            for (int i = 1; i < args.Length; i++)
            {
                oArgs[i - 1] = args[i];
            }
            _filter = ReflectionUtils.Construct<IFilter>(type, oArgs);
        }

        public ConfigurationFilter(Type type, params object[] args)
        {
            _filter = ReflectionUtils.Construct<IFilter>(type, args);
        }

        public IEvent Execute(IEvent value)
        {
            return _filter.Execute(value);
        }
    }
}
