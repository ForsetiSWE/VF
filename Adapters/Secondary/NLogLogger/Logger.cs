using NLog;
using ILogger = Umc.VigiFlow.Core.Ports.ILogger;

namespace Umc.VigiFlow.Adapters.Secondary.NLogLogger
{
    class Logger : ILogger
    {
        #region Setup

        private readonly NLog.Logger logger;

        public Logger()
        {
            ConfigureNLog();

            logger = LogManager.GetCurrentClassLogger();
        }

        #endregion Setup

        #region ILogger

        public void Info(string message)
        {
            logger.Info(message);
        }

        #endregion ILogger

        #region Private

        private static void ConfigureNLog()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = @"C:\Temp\logfile.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;
        }

        #endregion Private
    }
}
