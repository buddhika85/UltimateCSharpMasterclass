using static System.Console;

namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintPluses(30);
            PrintMinuses(30);

            WriteLine($"\nCores count: {Environment.ProcessorCount}");


            ReadKey();
        }

        private static void PrintPluses(int count)
        {
            WriteLine($"PrintPluses Thread ID : {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < count; i++)
            {
                Write("+");
            }
        }

        private static void PrintMinuses(int count)
        {
            WriteLine($"\nPrintMinuses Thread ID : {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < count; i++)
            {
                Write("-");
            }
        }
    }
}
