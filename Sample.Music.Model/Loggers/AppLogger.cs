using Sample.Music.Logger;
using Sample.Music.Model.Common;
using log4net;

namespace Sample.Music.Model.Loggers
{
    public static class AppLogger
    {
        private static readonly ILog _log;

        static AppLogger()
        {
            _log = LogMaster.GetLogger(Constants.APP_DEFAULT_LOG, Constants.APP_LOGS_PATH);
        }

        public static void Error(string message)
        {
            _log.Error(message);
        }

        public static void Error(string message, Exception e)
        {
            _log.Error(message, e);
        }

        public static void Info(string message)
        {
            _log.Info(message);
        }

        public static void Warn(string message)
        {
            _log.Warn(message);
        }
    }
}