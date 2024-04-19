namespace Multithreading
{
    internal class Exercise_1
    {
        public static void RunThreads()
        {
            //your code goes here
            var thread1 = new Thread(() => DisplayMessage());
            var thread2 = new Thread(() => DisplayMessage());   
            var thread3 =  new Thread(() => DisplayMessage());
            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        private static void DisplayMessage() => 
                Console.WriteLine($"Hello from thread with ID: {Thread.CurrentThread.ManagedThreadId}");
    }
}
