using static System.Console;
 
namespace GameDataParserModelAnswer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger("log.txt");
            try
            {
                var consoleUserInteractor = new ConsoleUserInteractor();
                new GameDataParserApp(consoleUserInteractor, 
                    new GamesPrinter(consoleUserInteractor),
                    new GamesJsonDesrializer(consoleUserInteractor),
                    new LocalFileReader()).Run();
            }
            catch (Exception e)
            {
                WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
                logger.Log(e);
            }

            WriteLine("Press any key to close.");
            ReadKey();
        }
    }

    public class VideoGame
    {
        public string Title { get; init; } = null!;
        public int ReleaseYear { get; init; }
        public decimal Rating { get; init; }

        public override string ToString() => $"{Title}, released in {ReleaseYear}, rating: {Rating}";        
    }
}
