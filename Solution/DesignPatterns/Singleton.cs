namespace DesignPatterns
{
    public class Singleton
    {
        public Guid Id { get; init; }

        // private constructor
        private Singleton()
        {
            Id = Guid.NewGuid();
        }



        private static Singleton _instance;

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Singleton();
                return _instance;
            }
        }

    }

    public class SingletonDemo
    {
        public static void Demo()
        {
            //var singleton = new Singleton();  // private access, not possible
            var singletonOne = Singleton.Instance;
            var singletonTwo = Singleton.Instance;

            Console.WriteLine(singletonOne.Id);
            Console.WriteLine(singletonTwo.Id);

        }
    }
}
