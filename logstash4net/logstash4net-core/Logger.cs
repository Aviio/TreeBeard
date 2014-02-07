using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using logstash4net.Configuration;
using logstash4net.Events;
using logstash4net.Filters;
using logstash4net.Inputs;
using logstash4net.Outputs;
using logstash4net.Utils;

namespace logstash4net
{
    public class Logger<TConfiguration> : ILogger
        where TConfiguration : class, IConfiguration
    {
        private event OutputEventHandler OutputEvent;
        private delegate void OutputEventHandler(object sender, OutputEventArgs e);

        private readonly List<IInput> _inputs;
        private readonly List<IFilter> _filters;
        private readonly List<IOutput> _outputs;
        private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

        public bool IsRunnable
        {
            get { return (_inputs != null && _filters != null && _outputs != null && _inputs.Count > 0 && _outputs.Count > 0); }
        }

        public Logger(params object[] args)
        {
            IConfiguration configuration = ReflectionUtils.Construct<TConfiguration>(args);
            _inputs = configuration.Inputs;
            _filters = configuration.Filters;
            _outputs = configuration.Outputs;
        }

        public void Dispose()
        {
            _subscriptions.ForEach(s => { if (s != null) s.Dispose(); });
        }

        public void Run()
        {
            if (!IsRunnable) return;

            // merge inputs
            IObservable<IEvent> filterSource = _inputs.Merge();

            // subscribe filters
            IObservable<IEvent> outputSource;
            if (_filters.Count > 0)
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
            foreach (IOutput output in _outputs)
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
            foreach (IFilter filter in _filters)
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
