using System;
using TreeBeard.Interfaces;

namespace TreeBeard.Exceptions
{
    public class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException(IConfiguration configuration)
            : base(GetMessage(configuration))
        {
        }

        public InvalidConfigurationException(IConfiguration configuration, Exception innerException)
            : base(GetMessage(configuration), innerException)
        {
        }

        private static string GetMessage(IConfiguration configuration)
        {
            // TODO give better explanation of configuration issue
            return "Invalid configuration";
        }
    }
}
