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

        public string AsString()
        {
            return $"Base is {_base}, height is {_height}";
        }
    }
}
