
using TreeBeard;
using TreeBeard.Configuration;
using TreeBeard.Inputs;
using TreeBeard.Interfaces;
using TreeBeard.Outputs;
using System;
using System.Collections.Generic;

namespace TreeBeard_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicConfiguration configuration = new BasicConfiguration()
                .AddInput("MongoDb:logs2", "mongodb://localhost:27017", "logstash", "logs2")
                .AddInput("MongoDb:logs3", "mongodb://localhost:27017", "logstash", "logs3")
                //.AddInput("File", @"D:\logstash\log-file.txt", @"^[\d]{4}-[\d]{2}-[\d]{2} [\d]{2}:[\d]{2}:[\d]{2}")
                .AddOutput("Console");       

            using (ILogger logger = new Logger<BasicConfiguration>(configuration))
            {
                logger.Execute();

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
