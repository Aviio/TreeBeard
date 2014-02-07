
using logstash4net.Events;

namespace logstash4net.Filters
{
    public interface IFilter
    {
        IEvent Execute(IEvent value);
    }
}
