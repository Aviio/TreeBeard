using System;

namespace logstash4net.Interfaces
{
    public interface ILogger : IDisposable
    {
        void Run();
    }
}
