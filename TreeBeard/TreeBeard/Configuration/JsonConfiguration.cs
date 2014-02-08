
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TreeBeard.Filters;
using TreeBeard.Inputs;
using TreeBeard.Outputs;
using TreeBeard.Interfaces;
using System.Reflection;

namespace TreeBeard.Configuration
{
    public class JsonConfiguration : IConfiguration
    {
        public List<IInput> Inputs { get; private set; }
        public List<IFilter> Filters { get; private set; }
        public List<IOutput> Outputs { get; private set; } 

        public JsonConfiguration(string fileName)
        {
            Inputs = new List<IInput>();
            Filters = new List<IFilter>();
            Outputs = new List<IOutput>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string json = sr.ReadToEnd();
                dynamic config = JsonConvert.DeserializeObject(json);

                foreach (dynamic input in config.inputs)
                {
                    AddInput(input.Name, input.Value);
                }
                foreach (dynamic filter in config.filters)
                {
                    AddFilter(filter.Name, filter.Value);
                }
                foreach (dynamic output in config.outputs)
                {
                    AddOutput(output.Name, output.Value);
                }
            }
        }

        private void AddInput(string name, dynamic args)
        {
            ConfigurationInput input = new ConfigurationInput();
            input.Initialize(GetArgs(name, args));
            Inputs.Add(input);
        }

        private void AddFilter(string name, dynamic args)
        {
            ConfigurationFilter filter = new ConfigurationFilter();
            filter.Initialize(GetArgs(name, args));
            Filters.Add(filter);
        }

        private void AddOutput(string name, dynamic args)
        {
            ConfigurationOutput output = new ConfigurationOutput();
            output.Initialize(GetArgs(name, args));
            Outputs.Add(output);
        }

        private string[] GetArgs(string name, dynamic args)
        {
            List<string> argsList = new List<string>();
            argsList.Add(name);
            foreach (string value in args)
            {
                argsList.Add(value);
            }
            return argsList.ToArray();
        }
    }
}
