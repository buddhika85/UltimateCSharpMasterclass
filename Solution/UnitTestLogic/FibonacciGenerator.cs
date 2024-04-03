namespace UnitTestLogic
{
    public class FibonacciGenerator
    {
        // n = 0 => 0
        // n = 1 => 1
        // n = 2 => fib(n-1) + fib(n-2) => fib(1) + fib(0) => 1 + 0 => 1
        // n = 3 => fib(n-1) + fib(n-2) => fib(2) + fib(1) => 1 + 1 => 2
        // n = 4 => fib(n-1) + fib(n-2) => fib(3) + fib(2) => 2 + 1 => 3
        public static int Fib(int n)
        {
            if (n == 0 || n == 1) return n;
            return Fib(n - 1) + Fib(n - 2);
        }
              
        public static IEnumerable<int> FibSequence(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException(
                    $"{nameof(n)} cannot be smaller than 0.");
            }

            const int MaxValidNumber = 46;
            if (n > MaxValidNumber)
            {
                throw new ArgumentException(
                    $"{nameof(n)} cannot be larger than {MaxValidNumber}, " +
                    $"as it will cause numeric overflow.");
            }

            var result = new List<int>();

            int a = -1;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int sum = a + b;
                result.Add(sum);
                a = b;
                b = sum;
            }

            return result;
        }
    }
}
