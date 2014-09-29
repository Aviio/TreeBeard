
using System;
using TreeBeard.Configuration;
using TreeBeard.Interfaces;

namespace TreeBeard.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            IConfiguration configuration;
            if (args.Length == 1)
            {
                configuration = new JsonConfiguration(args[0]);
            }
            else
            {
                configuration = new FluentConfiguration(@".\db")
                    .AddInput("MongoDb", "logs", "mongodb://localhost:27017", "logstash", "logs")
                    //.AddInput("MongoDb", "logs3", "mongodb://localhost:27017", "logstash", "logs3")
                    .AddInput("File", "1", @"D:\log-file.txt")
                    //.AddInput("File", "2", @"D:\log-file.txt")
                    //.AddFilter("RegExTimeStamp", "Type==\"File\" && Id==\"2\"", @"^[\d]{4}-[\d]{2}-[\d]{2} [\d]{2}:[\d]{2}:[\d]{2}", @"Message")
                    //.AddInput("SqlServer", "ServerName", "DatabaseName", "TableName", "TableId", "CurrentDate", "UserName", "Password")
                    .AddOutput("Console");
            }
#else
            IConfiguration configuration = new JsonConfiguration(args[0]);
#endif

            using (EventHerder eventHerder = new EventHerder(configuration))
            {
                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
