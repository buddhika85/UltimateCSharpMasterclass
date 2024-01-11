using GameDataParser.Helpers;

namespace GameDataParser
{
    public static class AppConfig
    {
        private const string LogFilePath = "log.txt";
        public static readonly Logger Logger = new(LogFilePath);
    }
}
