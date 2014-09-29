
namespace TreeBeard.Interfaces
{
    public interface IOutput : IInitializable
    {
        void Execute(Event value);
    }
}
