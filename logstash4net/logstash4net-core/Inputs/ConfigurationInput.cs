using System;
using logstash4net.Events;
using logstash4net.Utils;

namespace logstash4net.Inputs
{
    internal class ConfigurationInput : IInput
    {
        private readonly Type _inputType;
        private readonly object[] _args;

        public ConfigurationInput(params string[] args)
        {
            _inputType = Type.GetType(args[0], true);
            _args = new object[args.Length - 1];
            for (int i = 1; i < args.Length; i++)
            {
                _args[i - 1] = args[i];
            }
        }

        public ConfigurationInput(Type inputType, params object[] args)
        {
            _inputType = inputType;
            _args = args;
        }

        public IDisposable Subscribe(IObserver<IEvent> observer)
        {
            IInput input = ReflectionUtils.Construct<IInput>(_inputType, _args);

            return input.Subscribe(observer);
        }
    }
}
