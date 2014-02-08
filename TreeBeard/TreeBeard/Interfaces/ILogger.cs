using System;

namespace TreeBeard.Interfaces
{
    public interface ILogger : IDisposable
    {
        void Run();
    }
}
