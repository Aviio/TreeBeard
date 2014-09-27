
using System;
using TreeBeard.Events;
using TreeBeard.ExtensionMethods;
using TreeBeard.Utils;
using TreeBeard.Interfaces;

namespace TreeBeard.Outputs
{
    public class ConfigurationOutput : IOutput
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
