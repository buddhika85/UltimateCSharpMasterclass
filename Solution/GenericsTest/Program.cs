﻿using System.Reflection;
using static System.Console;
namespace GenericsTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TestListOfInts();
            //TestGenericListWithInts();
            //TestGenericListWithStrings();

            //TestPairOfInts();
            TestTuple();
        }

        private static void TestTuple()
        {
            List<int> nums = new(){1, 2, 3, 4, 5};
            var tuple = GetMinMaxTotalAvg(nums);
            WriteLine($"min: {tuple.min}\n" +
                $"max: {tuple.max}\n" +
                $"total: {tuple.total}\n" +
                $"average: {tuple.average}");
        }

        private static (int min, int max, int total, double average) GetMinMaxTotalAvg(IEnumerable<int> nums)
        {
            if (nums == null || !nums.Any())
                return default;

            var total = 0;
            var min = nums.First();
            var max = nums.First();
            foreach (var num in nums)
            {
                total += num;
                if (num < min)
                    min = num;
                if (num > max)
                    max = num;
            }
            return (
                min: min,
                max: max,
                total: total,
                average: total / nums.Count()
                );
        }

        private static void TestPairOfInts()
        {
            Pair<int> pairOfInts = new(1, 2);
            WriteLine($"First: {pairOfInts.First}, Second: {pairOfInts.Second}");
            pairOfInts.ResetFirst();
            pairOfInts.ResetSecond();
            WriteLine($"First: {pairOfInts.First}, Second: {pairOfInts.Second}");
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
