using logstash4net.Events;
using System;

namespace logstash4net.Outputs
{
    public class ConsoleOutput : IOutput
    {
        public void Execute(IEvent value)
        {
            Console.WriteLine(value.AsString());
        }
    }
}
