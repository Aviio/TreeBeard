
using System.Collections.Generic;
using logstash4net.Filters;
using logstash4net.Inputs;
using logstash4net.Outputs;

namespace logstash4net.Configuration
{
    public class BasicConfiguration : IConfiguration
    {
        public List<IInput> Inputs { get; private set; }
        public List<IFilter> Filters { get; private set; }
        public List<IOutput> Outputs { get; private set; }

        public BasicConfiguration(List<IInput> inputs, List<IFilter> filters, List<IOutput> outputs)
        {
            Inputs = inputs;
            Filters = filters;
            Outputs = outputs;
        }
    }
}
