using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class TasksDemo
    {
        public static void Demo()
        {
            Task<int> taskResult = Task.Run(() => CaculateLength("Hello there"));
            //Console.WriteLine($"{taskResult.Result}");

        }

        public static int CaculateLength(string str)
        {
            Console.WriteLine($"CaculateLength thread ID is  : {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep( 2000 );           // simulate a long running process
            return str.Length;
        }
    }
}
