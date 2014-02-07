
namespace logstash4net.Interfaces
{
    public interface IFilter : IInitializable
    {
        IEvent Execute(IEvent value);
    }
}
