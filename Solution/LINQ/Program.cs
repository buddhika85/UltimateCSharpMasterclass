namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsAnyWordWhiteSpace(new List<string> { }));       // f
            Console.WriteLine(IsAnyWordWhiteSpace(new List<string> { "hello", "There    " } ));     // f
            Console.WriteLine(IsAnyWordWhiteSpace(new List<string> { "hello", "    " }));           // true
        }

        public static bool IsAnyWordWhiteSpace(List<string> words)
        {
            return words.Any(word => word.All(c => char.IsWhiteSpace(c)));
        }
    }
}
