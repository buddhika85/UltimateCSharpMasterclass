using static System.Console;
namespace OtherTests.EqualityVsEquals
{
    public class CustomInt //: System.Object
    {
        private int _value;

        public CustomInt(int value)
        {
            _value = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            CustomInt? item = obj as CustomInt;
            return item?._value == _value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }

    public class Test
    {
        public void EqualityVsEquals()
        {
            var objOne = new CustomInt(1);
            var objTwo = new CustomInt(1);
            WriteLine($"== Comparison : {objOne == objTwo}");
            WriteLine($"Equals Comparison : {objOne.Equals(objTwo)}");
        }
    }
}
