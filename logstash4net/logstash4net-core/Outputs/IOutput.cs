
using logstash4net.Events;

namespace logstash4net.Outputs
{
    public interface IOutput
    {
        void Execute(IEvent value);
    }
}
