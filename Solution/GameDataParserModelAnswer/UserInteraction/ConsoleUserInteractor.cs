using static System.Console;

namespace GameDataParserModelAnswer.UserInteraction
{
    public class ConsoleUserInteractor : IUserInteractor
    {
        public void PrintError(string error)
        {
            var originalColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            PrintMessage(error);
            ForegroundColor = originalColor;
        }

        public void PrintMessage(string message)
        {
            WriteLine(message);
        }

        public string ReadValidFilePath()
        {
            bool isFilePathValid = false;
            string fileName = default;
            do
            {
                WriteLine("Enter the name of the file you want to read:");
                fileName = ReadLine();
                if (fileName is null)
                {
                    WriteLine("The file name cannot be null.");

                }
                else if (fileName == string.Empty)
                {
                    WriteLine("The file name cannot be empty.");
                }
                else if (!File.Exists(fileName))
                {
                    WriteLine("File not found.");
                }
                else
                {
                    isFilePathValid = true;
                }
            } while (!isFilePathValid);
            return fileName;
        }
    }
}
