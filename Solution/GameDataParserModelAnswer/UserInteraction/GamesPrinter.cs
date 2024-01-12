using GameDataParserModelAnswer.Model;

namespace GameDataParserModelAnswer.UserInteraction
{
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
}
