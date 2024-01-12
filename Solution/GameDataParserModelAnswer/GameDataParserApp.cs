using System.Text.Json;
using static System.Console;

namespace GameDataParserModelAnswer
{
    public class GameDataParserApp
    {
        public void Run()
        {
            bool isFileRead = false;
            string fileName = default;
            string fileContent = default;
            do
            {
                try
                {
                    WriteLine("Enter the name of the file you want to read:");
                    fileName = ReadLine();
                    fileContent = File.ReadAllText(fileName);
                    isFileRead = true;
                }
                catch (ArgumentNullException e)
                {
                    WriteLine("The file name cannot be null.");
                }
                catch (ArgumentException e)
                {
                    WriteLine("The file name cannot be empty.");
                }
                catch (FileNotFoundException e)
                {
                    WriteLine("File not found.");
                }
            } while (!isFileRead);

            List<VideoGame> games = default;


            try
            {
                games = JsonSerializer.Deserialize<List<VideoGame>>(fileContent);
            }
            catch (JsonException e)
            {
                var originalColor = ForegroundColor;
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"JSON in the {fileName} was not in a valid format. JSON body:" +
                    $"{Environment.NewLine}{fileContent}");
                ForegroundColor = originalColor;
                throw new JsonException($"{e.Message} The file is: {fileName}", e);
            }

            if (games.Count > 0)
            {
                WriteLine("\nLoaded games are:");
                foreach (var game in games)
                {
                    WriteLine(game);
                }
            }
            else
            {
                WriteLine("No ganes are present in the input file");
            }
        }
    }
}
