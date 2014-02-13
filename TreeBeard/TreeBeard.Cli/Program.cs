
using TreeBeard;
using TreeBeard.Configuration;
using TreeBeard.Inputs;
using TreeBeard.Interfaces;
using TreeBeard.Outputs;
using System;
using System.Collections.Generic;
using TreeBeard.Scripts.Inputs;
using TreeBeard.Scripts.Outputs;

namespace TreeBeard.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration;
            if (args.Length == 1)
            {
                configuration = new JsonConfiguration(args[0]);
            }
            else
            {
                // FOR LOCAL TESTING PURPOSES
                configuration = new FluentConfiguration()
                    //.AddInput("MongoDb", "logs2", "mongodb://localhost:27017", "logstash", "logs2")
                    //.AddInput("MongoDb", "logs3", "mongodb://localhost:27017", "logstash", "logs3")
                    //.AddInput("File", "1", @"D:\log-file.txt")
                    //.AddInput("File", "2", @"D:\log-file.txt")
                    //.AddFilter("RegExTimeStamp", "Type==\"File\" && Id==\"2\"", @"^[\d]{4}-[\d]{2}-[\d]{2} [\d]{2}:[\d]{2}:[\d]{2}")
                    .AddInput<SqlServerInput>("172.22.38.252", "GeorgeBancoMainDEV_RJC", "Log", "LogId", "CurrentDate", "***REMOVED***", "***REMOVED***")
                    .AddOutput<ConsoleOutput>();
            }
            using (IEventHerder eventHerder = new EventHerder(configuration))
            {
                eventHerder.Execute();

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
