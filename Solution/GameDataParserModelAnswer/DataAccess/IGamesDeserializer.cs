using GameDataParserModelAnswer.Model;

namespace GameDataParserModelAnswer.DataAccess
{
    public interface IGamesDeserializer
    {
        List<VideoGame> Deserialize(string fileName, string fileContent);
    }
}
