
using System;
using logstash4net.Events;

namespace logstash4net.Inputs
{
    public interface IInput : IObservable<IEvent>
    {
    }
}
