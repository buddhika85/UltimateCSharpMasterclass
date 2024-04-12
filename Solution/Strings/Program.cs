using static System.Console;

namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CharLoopDemo();
        }

        private static void CharLoopDemo()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Write($"{c}, ");
            }
        }
    }
}
