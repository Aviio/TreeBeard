using System;
using System.Configuration;
using System.ServiceProcess;
using TreeBeard.Configuration;

namespace TreeBeard.Service
{
    public class TreeBeardService : ServiceBase
    {
        private IDisposable _eventHerder;

        public TreeBeardService()
        {
            this.ServiceName = "TreeBeard";
            this.CanStop = true;
            this.CanPauseAndContinue = false;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            string configLocation = ConfigurationManager.AppSettings["jsonConfigurationFileLocation"];

            _eventHerder = new EventHerder(typeof(JsonConfiguration), configLocation);
        }

        protected override void OnStop()
        {
            if (_eventHerder != null) _eventHerder.Dispose();
        }
    }
}
