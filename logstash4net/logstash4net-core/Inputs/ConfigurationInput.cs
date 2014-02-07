using System;
using logstash4net.Events;
using logstash4net.ExtensionMethods;
using logstash4net.Utils;
using logstash4net.Interfaces;

namespace logstash4net.Inputs
{
    internal class ConfigurationInput : IInput
    {
        private IInput _input;

        public IObservable<IEvent> Execute()
        {
            return _input.Execute();
        }

        public void Initialize(params string[] args)
        {
            _input = ScriptUtils.ConstructInput(args[0], args.SubArray(1));
        }
    }
}
