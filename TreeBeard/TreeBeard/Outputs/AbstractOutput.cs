using TreeBeard.Interfaces;

namespace TreeBeard.Outputs
{
    public abstract class AbstractOutput : IOutput
    {
        public abstract void Execute(Event value);
        public abstract void Initialize(params string[] args);

        public virtual void Dispose() { }
    }
}
