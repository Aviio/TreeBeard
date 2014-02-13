
using System.Collections.Generic;
using TreeBeard.Filters;
using TreeBeard.Inputs;
using TreeBeard.Interfaces;
using TreeBeard.Outputs;

namespace TreeBeard.Configuration
{
    public class FluentConfiguration : IConfiguration
    {
        public List<IInput> Inputs { get; set; }
        public List<IFilter> Filters { get; set; }
        public List<IOutput> Outputs { get; set; }

        public FluentConfiguration()
        {
            Inputs = new List<IInput>();
            Filters = new List<IFilter>();
            Outputs = new List<IOutput>();
        }
    }

    public static class FluentConfigurationExtensions
    {
        public static FluentConfiguration AddInput(this FluentConfiguration configuration, params string[] args)
        {
            ConfigurationInput input = new ConfigurationInput();
            input.Initialize(args);
            configuration.Inputs.Add(input);

            return configuration;
        }

        public static FluentConfiguration AddFilter(this FluentConfiguration configuration, params string[] args)
        {
            ConfigurationFilter filter = new ConfigurationFilter();
            filter.Initialize(args);
            configuration.Filters.Add(filter);

            return configuration;
        }

        public static FluentConfiguration AddOutput(this FluentConfiguration configuration, params string[] args)
        {
            ConfigurationOutput output = new ConfigurationOutput();
            output.Initialize(args);
            configuration.Outputs.Add(output);

            return configuration;
        }
        public static FluentConfiguration AddInput<T>(this FluentConfiguration configuration, params string[] args)
            where T : IInput, new()
        {
            IInput input = new T();
            input.Initialize(args);
            configuration.Inputs.Add(input);

            return configuration;
        }

        public static FluentConfiguration AddFilter<T>(this FluentConfiguration configuration, params string[] args)
            where T : IFilter, new()
        {
            IFilter filter = new T();
            filter.Initialize(args);
            configuration.Filters.Add(filter);

            return configuration;
        }

        public static FluentConfiguration AddOutput<T>(this FluentConfiguration configuration, params string[] args)
            where T : IOutput, new()
        {
            IOutput output = new T();
            output.Initialize(args);
            configuration.Outputs.Add(output);

            return configuration;
        }
    }
}
