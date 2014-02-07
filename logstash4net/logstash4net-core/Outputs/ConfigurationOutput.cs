
using System;
using logstash4net.Events;
using logstash4net.Utils;

namespace logstash4net.Outputs
{
    internal class ConfigurationOutput : IOutput
    {
        private readonly IOutput _output;

        public ConfigurationOutput(params string[] args)
        {
            string name = args[0];
            object[] oArgs = new object[args.Length - 1];
            for (int i = 1; i < args.Length; i++)
            {
                oArgs[i - 1] = args[i];
            }
            _output = ScriptUtils.ConstructOutput(name, oArgs);
        }

        public ConfigurationOutput(Type type, params object[] args)
        {
            _output = ReflectionUtils.Construct<IOutput>(type, args);
        }

        public void Execute(IEvent value)
        {
            _output.Execute(value);
        }
    }
}
