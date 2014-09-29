
using System;
namespace TreeBeard.Interfaces
{
    public interface IOutput : IInitializable, IDisposable
    {
        void Execute(Event value);
    }
}
