using System;

namespace logstash4net
{
    public interface ILogger : IDisposable
    {
        void Run();
    }
}
