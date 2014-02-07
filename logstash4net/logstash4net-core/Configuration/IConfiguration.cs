
using System.Collections.Generic;
using logstash4net.Filters;
using logstash4net.Inputs;
using logstash4net.Outputs;

namespace logstash4net.Configuration
{
    public interface IConfiguration
    {
        List<IInput> Inputs { get; }
        List<IFilter> Filters { get; }
        List<IOutput> Outputs { get; } 
    }
}
