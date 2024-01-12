using System.Text.Json;
using static System.Console;

namespace GameDataParserModelAnswer
{
    public class GameDataParserApp
    {
        private readonly IUserInteractor _userInteractor;
        private readonly IGamesPrinter _gamesPrinter;
        private readonly IGamesDeserializer _gamesDeserializer;
        private readonly IFileReader _fileReader;

        public GameDataParserApp(IUserInteractor userInteractor, 
            IGamesPrinter gamesPrinter,
            IGamesDeserializer gamesDeserializer, 
            IFileReader fileReader)
        {
            _userInteractor = userInteractor;
            _gamesPrinter = gamesPrinter;
            _gamesDeserializer = gamesDeserializer;
            _fileReader = fileReader;
        }

        public void Run()
        {
            var fileName = _userInteractor.ReadValidFilePath();
            var fileContent = _fileReader.Read(fileName);
            var games = _gamesDeserializer.Deserialize(fileName, fileContent);
            _gamesPrinter.Print(games);
        }
    }

    public interface IFileReader
    {
        string Read(string fileName);
    }

    public class LocalFileReader : IFileReader
    {
        public string Read(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }

    public interface IGamesDeserializer
    {
        List<VideoGame> Deserialize(string fileName, string fileContent);
    }

    public class GamesJsonDesrializer : IGamesDeserializer
    {
        private readonly IUserInteractor _userInteractor;

        public GamesJsonDesrializer(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public List<VideoGame> Deserialize(string fileName, string fileContent)
        {
            try
            {
                return JsonSerializer.Deserialize<List<VideoGame>>(fileContent);
            }
            catch (JsonException e)
            {
                _userInteractor.PrintError($"JSON in the {fileName} was not in a valid format. JSON body:" +
                    $"{Environment.NewLine}{fileContent}");
                throw new JsonException($"{e.Message} The file is: {fileName}", e);
            }
        }
    }

    public interface IGamesPrinter
    {
        void Print(List<VideoGame> games); 
    }

    public class GamesPrinter : IGamesPrinter
    {
        private readonly IUserInteractor _userInteractor;

        public GamesPrinter(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public void Print(List<VideoGame> games)
        {
            if (games.Count > 0)
            {
                _userInteractor.PrintMessage($"{Environment.NewLine}Loaded games are:");
                foreach (var game in games)
                {
                    _userInteractor.PrintMessage(game.ToString());
                }
            }
            else
            {
                _userInteractor.PrintMessage("No ganes are present in the input file");
            }
        }
    }

    public interface IUserInteractor
    {
        string ReadValidFilePath();
        void PrintMessage(string message);
        void PrintError(string error);
    }

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
