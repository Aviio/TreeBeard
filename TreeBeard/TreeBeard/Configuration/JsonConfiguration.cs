
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

            string json = File.ReadAllText(fileName);
            dynamic config = JsonConvert.DeserializeObject(json);

            foreach (dynamic input in config.inputs)
            {
                AddInput(input);
            }
            foreach (dynamic filter in config.filters)
            {
                AddFilter(filter);
            }
            foreach (dynamic output in config.outputs)
            {
                AddOutput(output);
            }
        }

        private void AddInput(dynamic value)
        {
            ConfigurationInput input = new ConfigurationInput();

            string name = value.type;
            if (value.id != null)
            {
                name += ":" + value.id;
            }

            input.Initialize(GetArgs(name, value.args));
            Inputs.Add(input);
        }

        private void AddFilter(dynamic value)
        {
            ConfigurationFilter filter = new ConfigurationFilter();

            List<string> argsList = new List<string>();
            argsList.Add((string)value.type);
            argsList.Add((string)(value.predicate ?? string.Empty));
            if (value.args != null)
            {
                foreach (string item in value.args)
                {
                    argsList.Add(item);
                }
            }

            filter.Initialize(argsList.ToArray());
            Filters.Add(filter);
        }

        private void AddOutput(dynamic value)
        {
            ConfigurationOutput output = new ConfigurationOutput();

            output.Initialize(GetArgs((string)value.type, value.args));
            Outputs.Add(output);
        }

        private string[] GetArgs(string name, dynamic args)
        {
            List<string> argsList = new List<string>();
            argsList.Add(name);
            if (args != null)
            {
                foreach (string value in args)
                {
                    argsList.Add(value);
                }
            }
            return argsList.ToArray();
        }
    }
}
