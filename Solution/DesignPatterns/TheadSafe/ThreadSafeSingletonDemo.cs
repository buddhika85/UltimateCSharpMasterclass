namespace DesignPatterns.TheadSafe
{
    public class ThreadSafeSingletonDemo
    {
    }

    public sealed class Singleton
    {
        private static volatile Singleton instance; // Using 'volatile' to ensure ordering of operations
        private static readonly object syncLock = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                // First check without acquiring the lock (to improve performance)
                if (instance == null)
                {
                    lock (syncLock) // Acquire the lock only if the instance is still null
                    {
                        // Second check to ensure that the instance is still null inside the lock
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
    }

}
