using static System.Console;

namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"\nCores count: {Environment.ProcessorCount}");

            //SingleThreadedExample();
            MultiThreadedExample();
            ReadKey();
        }

        private static void MultiThreadedExample()
        {
            Thread thread1 = new Thread(() => PrintPluses(300) );
            Thread thread2 = new Thread(() => PrintMinuses(300) );            

            // still the threads are not started
            thread1.Start();
            thread2.Start();
        }

        private static void SingleThreadedExample()
        {
            PrintPluses(30);
            PrintMinuses(30);
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
