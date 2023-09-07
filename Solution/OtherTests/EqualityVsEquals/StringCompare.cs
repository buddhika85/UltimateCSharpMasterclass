using static System.Console;

namespace OtherTests.EqualityVsEquals
{
    public class StringCompare
    {
        public void Test()
        {
            var strOne = "A";
            var strTwo = "A";
            WriteLine(strOne == strTwo);
            WriteLine(strOne.Equals(strTwo));
        }
    }
}
