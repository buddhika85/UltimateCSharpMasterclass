using GameDataParserModelAnswer.UserInteraction;

namespace GameDataParserModelAnswer.DataAccess
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
}
