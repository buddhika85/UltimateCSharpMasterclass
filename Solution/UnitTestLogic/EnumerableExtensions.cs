namespace UnitTestLogic
{
    public static class EnumerableExtensions
    {
        public static int SumOfEvenNumbers(this IEnumerable<int> numbers)
        {
            return numbers.Where(x => x % 2 == 0).Sum();
        }
    }
}
