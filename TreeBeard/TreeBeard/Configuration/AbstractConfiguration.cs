using System.Collections.Generic;
using TreeBeard.Interfaces;

namespace TreeBeard.Configuration
{
    public abstract class AbstractConfiguration : IConfiguration
    {
        public virtual string KeyStoreLocation { get; protected set; }
        public virtual List<IInput> Inputs { get; protected set; }
        public virtual List<IFilter> Filters { get; protected set; }
        public List<IOutput> Outputs { get; protected set; }

        public virtual void Dispose()
        {
            if (Inputs != null) Inputs.ForEach(i => i.Dispose());
            if (Filters != null) Filters.ForEach(i => i.Dispose());
            if (Outputs != null) Outputs.ForEach(i => i.Dispose());
        }
    }
}
