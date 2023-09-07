using static System.Console;
namespace OtherTests.EqualityVsEquals
{
    public struct CustomIntStruct
    {
        private int _x;

        public CustomIntStruct(int x)
        {
            _x = x;
        }
    }

    public class ValueTypeCompare
    {
        public void Test()
        {
            int x = 1, y = 1;
            WriteLine(x == y);
            WriteLine(x.Equals(y));

            var firstStruct = new CustomIntStruct(1);
            var secondStruct = new CustomIntStruct(1);
            //WriteLine(firstStruct == secondStruct); // do not compile
            WriteLine(firstStruct.Equals(secondStruct));
        }
    }
}
