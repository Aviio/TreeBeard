
using System.Collections.Generic;

namespace logstash4net.Interfaces
{
    public interface IConfiguration
    {
        List<IInput> Inputs { get; }
        List<IFilter> Filters { get; }
        List<IOutput> Outputs { get; } 
    }
}
