namespace CookieCookbook.Extensions
{
    public static class EnumExtensions
    {
        public static string GetFileExtension(this FileFormat fileFormat) => fileFormat == FileFormat.Json ? ".json" : ".txt";
    }
}
