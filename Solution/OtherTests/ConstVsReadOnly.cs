namespace OtherTests
{
    public class ConstVsReadOnly
    {
        public const int x = 10;
        //public const Dog dog = new Dog("Blue", 5);
        //public const Point point = new Point();         // point is a struct
        public readonly int _y;

        public ConstVsReadOnly(int y)
        {
            _y = y;
        }

        public override string ToString()
        {
            return $"const {x}, readonly {_y}";
        }
    }

    public class ConstVsReadOnlyTesting
    {
        public ConstVsReadOnlyTesting()
        {
            ConstVsReadOnly objOne = new(10);
            Console.WriteLine(objOne);
            //obj.y = 100;
            //obj.X

            ConstVsReadOnly objTwo = new(14);
            Console.WriteLine(objTwo);
        }
    }
}
