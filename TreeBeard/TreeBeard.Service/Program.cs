using System.ServiceProcess;

namespace TreeBeard.Service
{
    static class Program
    {        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase.Run(new TreeBeardService());
        }
    }
}
