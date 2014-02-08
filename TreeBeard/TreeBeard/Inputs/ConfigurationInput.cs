using System;
using TreeBeard.Events;
using TreeBeard.ExtensionMethods;
using TreeBeard.Utils;
using TreeBeard.Interfaces;

namespace TreeBeard.Inputs
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
