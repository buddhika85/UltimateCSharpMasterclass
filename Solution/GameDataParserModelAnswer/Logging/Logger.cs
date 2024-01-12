
namespace GameDataParserModelAnswer.Logging
{
    internal class Logger
    {
        private string _logFile;

        public Logger(string logFile)
        {
            _logFile = logFile;
        }

        public void Log(Exception e)
        {
            var entry = $"[{DateTime.Now}], {Environment.NewLine}" +
                $"Exception message:{e.Message}, " +
                $"Stack trace:    {e.StackTrace}{Environment.NewLine}{Environment.NewLine}";
            File.AppendAllText(_logFile, entry);
        }
    }
}