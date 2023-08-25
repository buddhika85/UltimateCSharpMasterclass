namespace OtherTests.Extensions
{
    public static class StringExtensions
    {
        public static int CountLines(this string str) =>
            str.Split(Environment.NewLine).Length;

        public static string TakeNthLine(this string str, int index) =>
            str.Split(Environment.NewLine)[index];
    }
}
