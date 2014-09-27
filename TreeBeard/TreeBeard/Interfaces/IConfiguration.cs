
using System.Collections.Generic;

namespace TreeBeard.Interfaces
{
    public interface IConfiguration
    {
        string KeyStoreLocation { get; }
        List<IInput> Inputs { get; }
        List<IFilter> Filters { get; }
        List<IOutput> Outputs { get; } 
    }
}
