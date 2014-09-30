using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;

namespace TreeBeard.Service
{
    static class Program
    {    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            string parameter = string.Concat(args);
            switch (parameter)
            {
                case "--install":
                    ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                    break;
                case "--uninstall":
                    ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                    break;
                default:
                    ServiceBase.Run(new TreeBeardService());
                    break;
            }
        }
    }
}
