using GameDataParser.Helpers;
using GameDataParser.model;
using System.Text.Json;
using static System.Console;

namespace GameDataParser
{
    public class GameDataParserApp
    {
        private string _jsonFilePath = null!;
        private string? _jsonString;

        public void Run()
        {
            try
            {
                SetFilePath();
                WriteLine($"{Environment.NewLine}Reading : {_jsonFilePath}{Environment.NewLine}");
                _jsonString = GetJsonString(_jsonFilePath);
                var games = JsonDataHandler.DeserializeToGames(_jsonString);
                if (games == null)
                    return;
                DisplayGames(games);
            }
            catch (JsonException e)
            {
                AppConfig.Logger.LogException(e);
                ForegroundColor = ConsoleColor.Red;
                WriteLine(
                    $"{Environment.NewLine}JSON in the {_jsonFilePath} was not in a valid format. JSON body:{_jsonString}");
                ForegroundColor = ConsoleColor.White;
                WriteLine(
                    $"{Environment.NewLine}Sorry! The application has experienced an unexpected error and will have to be closed.");
            }
            catch (Exception e)
            {
                // global exception handling for entry point of the application
                AppConfig.Logger.LogException(e);
                WriteLine(
                    $"{Environment.NewLine}Sorry! The application has experienced an unexpected error and will have to be closed.");
            }
            finally
            {
                CloseApp();
            }
        }

        private static void CloseApp()
        {
            WriteLine($"{Environment.NewLine}Press any key to close");
            ReadKey();
        }

        private void DisplayGames(List<Game> games)
        {
            if (games.Count == 0)
                WriteLine("No games are present in the input file.");

            WriteLine("Loaded games are:");
            foreach (var game in games)
            {
                WriteLine(game);
            }
        }

        private string GetJsonString(string filePath)
        {
            // IOException : assuming that file may be opened by someone else
            var jsonString = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(jsonString))
                throw new Exception("Content in the JSON file empty");
            return jsonString;
        }

        private void SetFilePath()
        {
            bool again;
            do
            {
                var fileName = ReadFileName();
                if (fileName == null)
                {
                    again = true;
                    WriteLine("File name cannot be null");
                }
                else if (fileName.Trim() == string.Empty)
                {
                    again = true;
                    WriteLine("File name cannot be empty.");
                }
                else if (!File.Exists(fileName.Trim()))
                {
                    again = true;
                    WriteLine("File not found.");
                }
                else
                {
                    _jsonFilePath = fileName;
                    again = false;
                }
            } while (again);
        }

        private string? ReadFileName()
        {
            WriteLine("Enter the name of the file you want to read:");
            return ReadLine();
        }


    }
}
