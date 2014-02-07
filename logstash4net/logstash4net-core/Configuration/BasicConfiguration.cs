﻿
using System.Collections.Generic;
using logstash4net.Filters;
using logstash4net.Inputs;
using logstash4net.Outputs;
using logstash4net.Interfaces;

namespace logstash4net.Configuration
{
    public class BasicConfiguration : IConfiguration
    {
        public List<IInput> Inputs { get; set; }
        public List<IFilter> Filters { get; set; }
        public List<IOutput> Outputs { get; set; }

        public BasicConfiguration()
        {
            Inputs = new List<IInput>();
            Filters = new List<IFilter>();
            Outputs = new List<IOutput>();
        }
    }

    public static class BasicConfigurationExtensions
    {
        public static BasicConfiguration AddInput(this BasicConfiguration configuration, params string[] args)
        {
            ConfigurationInput input = new ConfigurationInput();
            input.Initialize(args);
            configuration.Inputs.Add(input);

            return configuration;
        }

        public static BasicConfiguration AddFilter(this BasicConfiguration configuration, params string[] args)
        {
            ConfigurationFilter filter = new ConfigurationFilter();
            filter.Initialize(args);
            configuration.Filters.Add(filter);

            return configuration;
        }

        public static BasicConfiguration AddOutput(this BasicConfiguration configuration, params string[] args)
        {
            ConfigurationOutput output = new ConfigurationOutput();
            output.Initialize(args);
            configuration.Outputs.Add(output);

            return configuration;
        }
    }
}