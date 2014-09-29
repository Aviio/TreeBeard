
using TreeBeard.Extensions;
using TreeBeard.Interfaces;

namespace TreeBeard.Outputs
{
    public class ConfigurationOutput : IOutput
    {
        private IOutput _output;

        public void Execute(Event value)
        {
            _output.Execute(value);
        }

        public void Initialize(params string[] args)
        {
            _output = args[0].ConstructOutput(args.SubArray(1));
        }
    }
}
