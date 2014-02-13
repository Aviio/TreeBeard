using System;
using TreeBeard.Interfaces;

namespace TreeBeard.Scripts.Outputs
{
    public class ConsoleOutput : IOutput
    {
        public void Execute(IEvent value)
        {
            Console.WriteLine(value.AsString());
        }

        public void Initialize(params string[] args)
        {
        }
    }
}
