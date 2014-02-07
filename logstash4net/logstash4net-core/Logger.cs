using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using logstash4net.Configuration;
using logstash4net.Events;
using logstash4net.Filters;
using logstash4net.Inputs;
using logstash4net.Outputs;
using logstash4net.Utils;
using logstash4net.Interfaces;

namespace logstash4net
{
    public class Logger<TConfiguration> : ILogger
        where TConfiguration : class, IConfiguration
    {
        private event OutputEventHandler OutputEvent;
        private delegate void OutputEventHandler(object sender, OutputEventArgs e);

        private readonly IConfiguration _configuration;
        private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

        public bool IsRunnable
        {
            get { return (_configuration != null && _configuration.Inputs != null && _configuration.Filters != null && _configuration.Outputs != null && _configuration.Inputs.Count > 0 && _configuration.Outputs.Count > 0); }
        }

        public Logger(TConfiguration configuration)
        {
            _configuration = configuration;

            ReflectionUtils.LoadReferencedAssemblies();
        }

        public Logger(params object[] args)
            : this(ReflectionUtils.Construct<TConfiguration>(args))
        {
        }

        public void Dispose()
        {
            _subscriptions.ForEach(s => { if (s != null) s.Dispose(); });
        }

        public void Run()
        {
            if (!IsRunnable) return;

            // merge inputs
            IObservable<IEvent> filterSource = (from input in _configuration.Inputs
                                               select input.Execute()).Merge();

            // subscribe filters
            IObservable<IEvent> outputSource;
            if (_configuration.Outputs.Count > 0)
            {
                Subscribe(filterSource, FilterEvent);
                outputSource = Observable.FromEventPattern<OutputEventHandler, OutputEventArgs>(action => { OutputEvent += action; }, action => { OutputEvent -= action; })
                    .Select(e => e.EventArgs.Event);
            }
            else
            {
                outputSource = filterSource;
            }    
            
            // subscribe outputs
            foreach (IOutput output in _configuration.Outputs)
            {
                Subscribe(outputSource, output.Execute);
            }
        }

        private void Subscribe<T>(IObservable<T> source, Action<T> handler)
        {
            _subscriptions.Add(source.Subscribe(handler));
        }

        private void FilterEvent(IEvent value)
        {
            foreach (IFilter filter in _configuration.Filters)
            {
                value = filter.Execute(value);
                if (value == null)
                {
                    return;
                }
            }
            OutputEvent(this, new OutputEventArgs(value));
        }
    }
}
