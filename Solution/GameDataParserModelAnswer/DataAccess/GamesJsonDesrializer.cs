using GameDataParserModelAnswer.Model;
using GameDataParserModelAnswer.UserInteraction;
using System.Text.Json;

namespace GameDataParserModelAnswer.DataAccess
{
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
}
