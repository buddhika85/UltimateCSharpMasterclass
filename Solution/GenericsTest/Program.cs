using System.Reflection;
using static System.Console;
namespace GenericsTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TestListOfInts();
            TestGenericListWithInts();
            TestGenericListWithStrings();
        }

        private static void TestGenericListWithStrings()
        {
            try
            {
                SimpleList<string> words = new();
                WriteLine(words);
                words.Add("Apple");
                WriteLine(words);
                words.Add("Orange");
                words.Add("Banana");
                words.Add("Guava");
                WriteLine(words);
                words.Add("Grapes");
                WriteLine(words);

                words.RemoveAt(4);
                WriteLine(words);
                words.RemoveAt(1);
                WriteLine(words);
                words.RemoveAt(0);
                WriteLine(words);
                //listOfInts.RemoveAt(3);
                //listOfInts.RemoveAt(-1);

                WriteLine($"{Environment.NewLine}Index {0} -> {words.GetAtIndex(0)}");
                WriteLine($"Index {1} -> {words.GetAtIndex(1)}");
                WriteLine($"Index {2} -> {words.GetAtIndex(2)}");
                WriteLine($"Index {3} -> {words.GetAtIndex(3)}");
            }
            catch (Exception e)
            {
                WriteLine($"Exception [{MethodBase.GetCurrentMethod()}] - {e?.Message}");
            }
        }

        private static void TestGenericListWithInts()
        {
            try
            {
                SimpleList<int> listOfInts = new();
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

                WriteLine($"{Environment.NewLine}Index {0} -> {listOfInts.GetAtIndex(0)}");
                WriteLine($"Index {1} -> {listOfInts.GetAtIndex(1)}");
                WriteLine($"Index {2} -> {listOfInts.GetAtIndex(2)}");
                WriteLine($"Index {3} -> {listOfInts.GetAtIndex(3)}");
            }
            catch (Exception e)
            {
                WriteLine($"Exception [{MethodBase.GetCurrentMethod()}] - {e?.Message}");
            }
        }

        private static void TestListOfInts()
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

                WriteLine($"{Environment.NewLine}Index {0} -> {listOfInts.GetAtIndex(0)}");
                WriteLine($"Index {1} -> {listOfInts.GetAtIndex(1)}");
                WriteLine($"Index {2} -> {listOfInts.GetAtIndex(2)}");
                WriteLine($"Index {3} -> {listOfInts.GetAtIndex(3)}");
            }
            catch (Exception e)
            {
                WriteLine($"Exception [{MethodBase.GetCurrentMethod()}] - {e?.Message}");
            }
        }
    }
}
