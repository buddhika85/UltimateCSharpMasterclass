namespace CookieCookbookModelAnswer.DataAccess;

public class StringsTextualRepository : StringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    protected override string StringsToText(List<string> strings)
    {
        return string.Join(Separator, strings);
    }

    protected override List<string> TextToStrings(string content)
    {
        return content.Split(Separator).ToList();
    }
}