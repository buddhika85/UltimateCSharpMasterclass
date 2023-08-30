using System.Text.Json;

namespace CookieCookbookModelAnswer.DataAccess;

public class StringsJsonRepository : StringsRepository
{
    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToStrings(string content)
    {
        var result = JsonSerializer.Deserialize<List<string>>(content);
        return result ?? new List<string>();
    }
}