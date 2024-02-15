using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace OtherTests.LambdaExpressions
{
    public class LambdaDemo
    {
        public void Demo()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            // using funcs
            //var result = IsAny(numbers, IsEven);
            //WriteLine($"IsEven : {result}");
            //result = IsAny(numbers, IsGreaterThan10);
            //WriteLine($"IsGreaterThan10 : {result}");

            // using lambda expressions
            var result = IsAny(numbers, x => x % 2 == 0);
            WriteLine($"IsEven : {result}");
            result = IsAny(numbers, x => x > 10);
            WriteLine($"IsGreaterThan10 : {result}");
        }

        public bool IsAny(IEnumerable<int> numbers, 
            Func<int, bool> predicate)
        {
            return numbers.Any(x => predicate(x));
        }

        //public bool IsEven(int num)
        //{
        //    return num % 2 == 0;
        //}

        //public bool IsGreaterThan10(int num)
        //{
        //    return num > 10;
        //}
    }
}
