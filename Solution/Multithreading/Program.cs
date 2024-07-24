using static System.Console;

namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //WriteLine($"\nCores count: {Environment.ProcessorCount}");

            //SingleThreadedExample();
            //bool useTasks = true;
            //MultiThreadedOrTasksExample(useTasks);

            //Exercise_1.RunThreads();

            //ThreadPoolDemo.Start100Threads();
            //ThreadPoolDemo.UseThreadPool();

            TasksDemo.Demo();

            ReadKey();
        }

        private static void MultiThreadedOrTasksExample(bool useTasks)
        {
            if (!useTasks)
            {
                Thread thread1 = new Thread(() => PrintPluses(300));
                Thread thread2 = new Thread(() => PrintMinuses(300));

                // still the threads are not started
                thread1.Start();
                thread2.Start();               
            }
            else
            {
                //Task task1 = new Task(() => PrintPluses(200));
                //Task task2 = new Task(() => PrintMinuses(200));

                //task1.Start();
                //task2.Start();

                Task task1 = Task.Run(() => PrintPluses(200));
                Task task2 = Task.Run(() => PrintMinuses(200));
            }

            Write("Program finished!!");
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
