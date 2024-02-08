namespace OtherTests.FuncsAndActions
{
    using static System.Console;
    public class FuncDemo
    {
        public void Demo()
        {
            //FuncDemo funcDemo = new();
            //var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            //WriteLine($"IsAnyGreaterTo10 => {funcDemo.IsAnyGreaterTo10(numbers)}");
            //WriteLine($"IsAnyEven => {funcDemo.IsAnyEven(numbers)}");

            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            Func<int, bool> isEvenFunc = IsEven;
            WriteLine($"Is Any Greater To 10 => {IsAny(numbers, isEvenFunc)}");

            WriteLine($"Is Any Even => {IsAny(numbers, IsGreaterTo10)}");
        }

        public bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        public bool IsGreaterTo10(int num)
        {
            return num > 10;
        }
        public bool IsAny(IEnumerable<int> numbers, Func<int, bool> predicate)
        {
            return numbers.Any(x => predicate(x));
        }

        public bool IsAnyGreaterTo10(IEnumerable<int> numbers)
        {
            return numbers.Any(x => x > 10);
        }
        public bool IsAnyEven(IEnumerable<int> numbers)
        {
            return numbers.Any(x => x % 2 == 0);
        }
    }
}
