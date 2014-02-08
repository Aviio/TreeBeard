
namespace TreeBeard.Interfaces
{
    public interface IOutput : IInitializable
    {
        void Execute(IEvent value);
    }
}
