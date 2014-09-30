
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TreeBeard.Filters;
using TreeBeard.Inputs;
using TreeBeard.Interfaces;
using TreeBeard.Outputs;

namespace TreeBeard.Configuration
{
    public class JsonConfiguration : AbstractConfiguration
    {
        public JsonConfiguration(string fileName)
        {
            Inputs = new List<IInput>();
            Filters = new List<IFilter>();
            Outputs = new List<IOutput>();

            string json = File.ReadAllText(fileName);
            dynamic config = JsonConvert.DeserializeObject(json);

            KeyStoreLocation = config.keyStoreLocation;
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

            input.Initialize(GetArgs((string)value.type, (string)(value.alias ?? string.Empty), value.args));
            Inputs.Add(input);
        }

        private void AddFilter(dynamic value)
        {
            ConfigurationFilter filter = new ConfigurationFilter();

            filter.Initialize(GetArgs((string)value.type, (string)(value.predicate ?? string.Empty), value.args));
            Filters.Add(filter);
        }

        private void AddOutput(dynamic value)
        {
            ConfigurationOutput output = new ConfigurationOutput();

            output.Initialize(GetArgs((string)value.type, value.args));
            Outputs.Add(output);
        }

        private string[] GetArgs(string v1, dynamic args)
        {
            List<string> argsList = new List<string>();
            argsList.Add(v1);
            if (args != null)
            {
                foreach (string value in args)
                {
                    argsList.Add(value);
                }
            }
            return argsList.ToArray();
        }

        private string[] GetArgs(string v1, string v2, dynamic args)
        {
            List<string> argsList = new List<string>();
            argsList.Add(v1);
            argsList.Add(v2);
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
