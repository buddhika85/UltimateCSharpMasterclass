using GameDataParser.model;
using System.Text.Json;

namespace GameDataParser.Helpers
{
    public static class JsonDataHandler
    {
        // passing a valid json string is the responsibility of the caller of this method
        public static List<Game>? DeserializeToGames(string jsonString)
        {
            var result = JsonSerializer.Deserialize<List<Game>>(jsonString);
            return result ?? new List<Game>();
        }
    }
}
