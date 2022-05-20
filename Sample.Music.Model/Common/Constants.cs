namespace Sample.Music.Model.Common
{
    public class Constants
    {
        public const string APP_POLICY = "AppPolicy";

        #region Application Logger Strategy
        public const string APP_LOGS_PATH = "./Logs/";
        public const string APP_DEFAULT_LOG = "Default_Log";
        #endregion

        #region Exception Message Key Constants
        public const string EXCEPTION_MESSAGEKEY_NONOBJECTFOUND = "No Object Found";
        public const string EXCEPTION_MESSAGEKEY_NONEQUALOBJECT = "Objects Are Not Equal";
        public const string EXCEPTION_MESSAGEKEY_EQUALUNIQUEROW = "Unique Key Duplicated";
        #endregion
    }
}