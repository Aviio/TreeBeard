
using TreeBeard.Extensions;
using TreeBeard.Interfaces;

namespace TreeBeard.Outputs
{
    public class ConfigurationOutput : AbstractOutput
    {
        private IOutput _output;

        public override void Execute(Event value)
        {
            _output.Execute(value);
        }

        public override void Initialize(params string[] args)
        {
            _output = args[0].ConstructOutput(args.SubArray(1));
        }

        public override void Dispose()
        {
            if (_output != null) _output.Dispose();
            base.Dispose();
        }
    }
}
