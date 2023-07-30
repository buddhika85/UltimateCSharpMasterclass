namespace OtherTests
{
    public class Triangle
    {
        private readonly int _base;
        private readonly int _height;

        public Triangle(int @base, int height)
        {
            _base = @base;
            _height = height;
        }

        public int CalculateArea()
        {
            return (_base * _height) / 2;
        }

        //public string AsString()
        //{
        //    var str = $"Base is {_base}, height is {_height}";
        //    return str;
        //}

        public string AsString() => $"Base is {_base}, height is {_height}";

        public void Display() => Console.WriteLine("Test");

    }

}
