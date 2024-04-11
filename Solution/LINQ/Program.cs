using static System.Console;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine(IsAnyWordWhiteSpace(new List<string> { }));       // f
            WriteLine(IsAnyWordWhiteSpace(new List<string> { "hello", "There    " } ));     // f
            WriteLine(IsAnyWordWhiteSpace(new List<string> { "hello", "    " }));           // true

            WriteLine(CountListsContainingZeroLongerThan(3, new List<List<int>>
                                                                    {
                                                                        new List<int> { 1, 2, 5, -1},
                                                                        new List<int> { 0, 4, 4, 6},
                                                                        new List<int> { 9, 0 }
                                                                    }
            ));     // 1

            WriteLine(FindShortestWord(new List<string> { "aaa", "b", "c", "dd"  }));       // b
        }

        public static bool IsAnyWordWhiteSpace(List<string> words)
        {
            return words.Any(word => word.All(c => char.IsWhiteSpace(c)));
        }

        public static int CountListsContainingZeroLongerThan(int length, List<List<int>> listsOfNumbers)
        {
            return listsOfNumbers.Count(list => list.Count > length && list.Contains(0));
        }

        public static string FindShortestWord(List<string> words)
        {
            return words.OrderBy(x => x.Length).First();
        }

        public static IEnumerable<DateTime> GetFridaysOfYear(int year, IEnumerable<DateTime> dates)
        {
            return dates.Where(x => x.Year == year && x.DayOfWeek == DayOfWeek.Friday).Distinct();
        }
    }
}
