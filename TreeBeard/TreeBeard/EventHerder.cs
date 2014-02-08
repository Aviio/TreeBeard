using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using TreeBeard.Configuration;
using TreeBeard.Events;
using TreeBeard.Filters;
using TreeBeard.Inputs;
using TreeBeard.Outputs;
using TreeBeard.Utils;
using TreeBeard.Interfaces;

namespace TreeBeard
{
    //public class EventHerder<TConfiguration> : IEventHerder
    //    where TConfiguration : class, IConfiguration
    public class EventHerder : IEventHerder
    {
        private event OutputEventHandler OutputEvent;
        private delegate void OutputEventHandler(object sender, OutputEventArgs e);

        private readonly IConfiguration _configuration;
        private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

        public bool IsExecutable
        {
            get { return (_configuration != null && _configuration.Inputs != null && _configuration.Filters != null && _configuration.Outputs != null && _configuration.Inputs.Count > 0 && _configuration.Outputs.Count > 0); }
        }

        public EventHerder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EventHerder(Type configurationType, params object[] args)
            : this(ReflectionUtils.Construct(configurationType, args) as IConfiguration)
        {
        }

        //public EventHerder(params object[] args)
        //    : this(ReflectionUtils.Construct<TConfiguration>(args))
        //{
        //}

        public void Dispose()
        {
            _subscriptions.ForEach(s => { if (s != null) s.Dispose(); });
        }

        public void Execute()
        {
            if (!IsExecutable) return;

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
