
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using logstash4net.Filters;
using logstash4net.Inputs;
using logstash4net.Outputs;
using logstash4net.Interfaces;

namespace logstash4net.Configuration
{
    public class JsonConfiguration : IConfiguration
    {
        public List<IInput> Inputs { get; private set; }
        public List<IFilter> Filters { get; private set; }
        public List<IOutput> Outputs { get; private set; } 

        public JsonConfiguration(string fileName)
        {
            // TODO load inputs/filters/outputs from config
            using (StreamReader sr = new StreamReader(fileName))
            {
                string json = sr.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
            }
        }
    }
}
