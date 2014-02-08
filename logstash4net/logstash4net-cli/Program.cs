
using logstash4net;
using logstash4net.Configuration;
using logstash4net.Inputs;
using logstash4net.Interfaces;
using logstash4net.Outputs;
using System;
using System.Collections.Generic;

namespace logstash4net_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicConfiguration configuration = new BasicConfiguration()
                .AddInput("MongoDb", "mongodb://localhost:27017", "logstash", "logs2")
                .AddInput("MongoDb", "mongodb://localhost:27017", "logstash", "logs3")
                .AddInput("File", @"D:\logstash\log-file.txt", @"^[\d]{4}-[\d]{2}-[\d]{2} [\d]{2}:[\d]{2}:[\d]{2}")
                .AddOutput("Console");       

            using (ILogger logger = new Logger<BasicConfiguration>(configuration))
            {
                logger.Run();

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
