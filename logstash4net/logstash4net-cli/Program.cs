
using System;
using logstash4net;
using logstash4net.Configuration;
using System.Collections.Generic;
using logstash4net.Inputs;
using logstash4net.Filters;
using logstash4net.Outputs;

namespace logstash4net_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IInput> inputs = new List<IInput>();
            inputs.Add(new MongoDbInput("mongodb://localhost:27017", "logstash", "logs2"));
            inputs.Add(new MongoDbInput("mongodb://localhost:27017", "logstash", "logs3"));
            inputs.Add(new FileInput(@"D:\logstash\log-file.txt", @"^[\d]{4}-[\d]{2}-[\d]{2} [\d]{2}:[\d]{2}:[\d]{2}"));

            List<IFilter> filters = new List<IFilter>();

            List<IOutput> outputs = new List<IOutput>();
            outputs.Add(new ConsoleOutput());


            using (ILogger logger = new Logger<BasicConfiguration>(inputs, filters, outputs))
            {
                logger.Run();

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
