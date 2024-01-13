using static System.Console;
namespace GenericsTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ListOfInts listOfInts = new();
                WriteLine(listOfInts);
                listOfInts.Add(1);
                WriteLine(listOfInts);
                listOfInts.Add(2);
                listOfInts.Add(3);
                listOfInts.Add(4);
                WriteLine(listOfInts);
                listOfInts.Add(5);
                WriteLine(listOfInts);

                listOfInts.RemoveAt(4);
                WriteLine(listOfInts);
                listOfInts.RemoveAt(1);
                WriteLine(listOfInts);
                listOfInts.RemoveAt(0);
                WriteLine(listOfInts);
                //listOfInts.RemoveAt(3);
                //listOfInts.RemoveAt(-1);
            }
            catch (Exception e)
            {
                WriteLine($"Exception: {e?.Message}");
            }
        }
    }

    public class ListOfInts
    {
        private int[] _items = new int[4];
        private int _size = 0;

        public void Add(int item)
        {
            if (_size == _items.Length)
            {
                var temp = _items;
                // resize the array
                _items = new int[_size * 2];
                // copy
                for (var i = 0; i < temp.Length; i++)
                {
                    _items[i] = temp[i];
                }
            }
            // add new one
            _items[_size++] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range for the list with size {_size}");
            }

            // remove last element
            if (index == _size - 1)
            {
                _items[index] = default;
                _size--;
                return;
            }

            // remove any element other than last
            for (var i = index + 1; i < _size; i++)
            {
                _items[i - 1] = _items[i];
            }
            _items[--_size] = default;
        }

        public override string ToString()
        {
            var str = $"{Environment.NewLine}List Of Ints - size {_size}";
            for (var i = 0; i < _size; i++)
            {
                str += $"{Environment.NewLine}{i} -> {_items[i]}";
            }
            return str;
        }
    }
}
