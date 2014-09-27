using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using TreeBeard.ExtensionMethods;
using TreeBeard.Interfaces;
using TreeBeard.Utils;

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

            // set keystore location
            KeyStore.SetLocation(_configuration.KeyStoreLocation);

            // merge inputs
            IObservable<IEvent> filterSource = (from input in _configuration.Inputs
                                               select input.Execute()).Merge();

            // subscribe filters
            IObservable<IEvent> outputSource;
            if (_configuration.Filters.Count > 0)
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
            //Log.Information("Filter", "Input", value.AsString());
            //int i = 0;
            foreach (IFilter filter in _configuration.Filters)
            {
                //string logName = "Filter" + (++i).ToString();
                if ((filter.Predicate != null) ? filter.Predicate(value) : true)
                {
                    value = filter.Execute(value);
                    if (value == null)
                    {
                        //Log.Information(logName, "Drop", null);
                        return;
                    }
                    //Log.Information(logName, "Intermediate", value.AsString());
                }
                //else
                //{
                //    Log.Information(logName, "Ignored", value.AsString());
                //}
            }
            //Log.Information("Filter", "Output", value.AsString());
            OutputEvent(this, new OutputEventArgs(value));
        }
    }
}
