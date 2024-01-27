using System.Numerics;
using static System.Console;

namespace OtherTests.GenericTypesMath
{
    public static class GenericTypesMathDemo
    {
        public static void Demo()
        {
            WriteLine($"Square of 4 is : {Calculator.Square(4)}");
            WriteLine($"Square of 8.9m is : {Calculator.Square(8.9m)}");
            WriteLine($"Square of 456.567d is : {Calculator.Square(456.567d)}");
        }
    }


    public static class Calculator
    {
        public static T Square<T>(T num) where T : INumber<T>
        {
            return num * num;
        }
    }
}
