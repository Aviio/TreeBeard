﻿
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
            IConfiguration configuration;
            if (args.Length == 1)
            {
                configuration = new JsonConfiguration(args[0]);
            }
            else
            {
                // FOR LOCAL TESTING PURPOSES
                configuration = new FluentConfiguration()
                    .AddInput("MongoDb:logs2", "mongodb://localhost:27017", "logstash", "logs2")
                    .AddInput("MongoDb:logs3", "mongodb://localhost:27017", "logstash", "logs3")
                    .AddInput("File", @"D:\log-file.txt", @"^[\d]{4}-[\d]{2}-[\d]{2} [\d]{2}:[\d]{2}:[\d]{2}")
                    .AddOutput("Console");
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