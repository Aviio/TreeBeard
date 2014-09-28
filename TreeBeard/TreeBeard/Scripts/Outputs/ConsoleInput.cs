using System;
using TreeBeard.Events;
using TreeBeard.Interfaces;

namespace TreeBeard.Scripts.Outputs
{
    public class ConsoleOutput : IOutput
    {
        public void Execute(Event value)
        {
            Console.WriteLine(value.AsString());
        }

        public void Initialize(params string[] args)
        {
        }
    }
}
