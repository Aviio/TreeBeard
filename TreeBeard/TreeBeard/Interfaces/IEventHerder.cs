using System;

namespace TreeBeard.Interfaces
{
    public interface IEventHerder : IDisposable
    {
        void Execute();
    }
}
