using System.Diagnostics;

namespace Multithreading
{
    internal class ThreadPoolDemo
    {
        public static void UseThreadPool()
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                ThreadPool.QueueUserWorkItem(Print);
            }
            sw.Stop();
            Console.WriteLine($"\nUsing thread pool and doing 10000 iterations took: {sw.ElapsedMilliseconds} ms\n");
        }

        public static void Start100Threads()
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                Thread thread = new Thread(() => Print(new object()));
                thread.Start();
            }
            sw.Stop();
            Console.WriteLine($"\nCreating and starting 10000 threads took: {sw.ElapsedMilliseconds} ms\n");
        }

        private static void Print(Object? obj)
        {
            Console.Write("A");
        }
    }
}
