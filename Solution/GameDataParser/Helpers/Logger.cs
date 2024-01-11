namespace GameDataParser.Helpers
{
    public class Logger
    {
        private readonly string _logFilePath;

        public Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
            if (!File.Exists(logFilePath))
            {
                File.Create(_logFilePath);
            }
        }


        public void LogException(Exception exception)
        {
            var message = $"{Environment.NewLine}[{DateTime.Now}]{Environment.NewLine}, " +
                          $"Exception message:{exception.Message}, " +
                          $"Stack trace:    {exception.StackTrace}{Environment.NewLine}";
            WriteToLogFile(message);
        }


        private void WriteToLogFile(string logMessage)
        {
            using StreamWriter streamWriter = new(_logFilePath, true);
            streamWriter.WriteLine(logMessage);
        }
    }
}
