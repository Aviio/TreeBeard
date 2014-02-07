
using System;

namespace logstash4net.Interfaces
{
    public interface IInput : IInitializable
    {
        IObservable<IEvent> Execute();
    }
}
