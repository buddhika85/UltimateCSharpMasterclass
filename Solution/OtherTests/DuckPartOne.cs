namespace OtherTests
{
    public partial class Duck
    {
        public string Color { get; init; }

        public Duck(string color)
        {
            Color = color;
        }

        public void Quack() => Console.WriteLine("Quack Quack..");

        public void Swim()
        {
            Console.WriteLine("Im swimming in a pond.");
        }

        //public void Fly(){}
    }
}
