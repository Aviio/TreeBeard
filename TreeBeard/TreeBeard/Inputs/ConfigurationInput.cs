using System;
using TreeBeard.ExtensionMethods;
using TreeBeard.Interfaces;
using TreeBeard.Utils;

namespace TreeBeard.Inputs
{
    internal class ConfigurationInput : AbstractInput
    {
        private IInput _input;

        public override IObservable<IEvent> Execute()
        {
            return _input.Execute();
        }

        public override void Initialize(params string[] args)
        {
            _input = ScriptUtils.ConstructInput(args[0], args.SubArray(1));
        }
    }
}
