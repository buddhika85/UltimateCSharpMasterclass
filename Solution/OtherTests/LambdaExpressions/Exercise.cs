using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherTests.LambdaExpressions
{
    public class Exercise
    {
        // GetLength stores a function taking a string and returning its length.
        public Func<string, int> GetLength = (x) => x.Length;

        // GetRandomNumberBetween1And10 stores a parameterless function generating a random number between 1 and 10.
        public Func<int> GetRandomNumberBetween1And10 = () => new Random().Next(1, 11);
    }
}
