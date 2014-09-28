
using System;
using System.Collections.Generic;
using System.Linq;
using TreeBeard.Events;
using TreeBeard.Exceptions;
using TreeBeard.Interfaces;
using TreeBeard.Utils;

namespace TreeBeard
{
    public class EventHerder : IDisposable
    {
        private readonly IDisposable _pipeline;

        public EventHerder(IConfiguration configuration)
        {
            // check configuration validity
            if (!IsConfigurationValid(configuration)) throw new InvalidConfigurationException(configuration);

            // initialize keystore
            KeyStore.Initialize(configuration.KeyStoreLocation);

            // create pipeline
            _pipeline = new Pipeline<Event>(
                    configuration.Inputs.Select(i => i.Execute()),
                    configuration.Filters.Select(f => new KeyValuePair<Func<Event, bool>, Func<Event, Event>>(f.Predicate, f.Execute)),
                    configuration.Outputs.Select<IOutput, Action<Event>>(o => o.Execute)
                );
        }

        public EventHerder(Type configurationType, params object[] args)
            : this(ReflectionUtils.Construct(configurationType, args) as IConfiguration)
        {
        }

        public void Dispose()
        {
            if (_pipeline != null) _pipeline.Dispose();
        }

        private bool IsConfigurationValid(IConfiguration configuration)
        {
            return (configuration != null && configuration.Inputs != null && configuration.Filters != null && configuration.Outputs != null && configuration.Inputs.Count > 0 && configuration.Outputs.Count > 0);
        }
    }
}
