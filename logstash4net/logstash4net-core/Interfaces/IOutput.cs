
namespace logstash4net.Interfaces
{
    public interface IOutput : IInitializable
    {
        void Execute(IEvent value);
    }
}
