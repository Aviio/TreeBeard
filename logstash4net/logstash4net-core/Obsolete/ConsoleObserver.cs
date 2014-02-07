using System;

namespace logstash4net.Obsolete
{
    internal class ConsoleObserver : IObserver<string>
    {
        public void OnNext(string value)
        {
            Console.WriteLine("OnNext: {0}", value);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("OnError: {0}", error.Message);
        }

        public void OnCompleted()
        {
            Console.WriteLine("OnCompleted");
        }
    }
}
