
namespace TreeBeard.Interfaces
{
    public interface IFilter : IInitializable
    {
        IEvent Execute(IEvent value);
    }
}
