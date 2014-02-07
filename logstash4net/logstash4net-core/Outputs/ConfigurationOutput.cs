
using System;
using logstash4net.Events;
using logstash4net.ExtensionMethods;
using logstash4net.Utils;
using logstash4net.Interfaces;

namespace logstash4net.Outputs
{
    internal class ConfigurationOutput : IOutput
    {
        private IOutput _output;

        public void Execute(IEvent value)
        {
            _output.Execute(value);
        }

        public void Initialize(params string[] args)
        {
            _output = ScriptUtils.ConstructOutput(args[0], args.SubArray(1));
        }
    }
}
