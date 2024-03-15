using OtherTests.FuncsAndActions.Practise;
using static System.Console;

//var point = new Point();
//point.Display();
//point.MoveRight(2);
//point.MoveUp(4);
//point.Display();


//new Test();

//using OtherTests.InheritanceAndPolymorphism;
////Console.WriteLine($"{string.Join(',', new Exercise().GetCountsOfAnimalsLegs())}");

//var list = new List<string> { "bobcat", "wolverine", "grizzly" };
//Console.WriteLine($"{string.Join(',', new Exercise2().ProcessAll(list))}");

//new OtherTests.ConstructorsTest.Test();

//var str = @"Line 1
//Line2
//Line3";
//WriteLine($"Line count: {str.CountLines()}");
//for (var i = 0; i < str.CountLines(); i++)
//{
//    WriteLine($"Index {i} line: {str.TakeNthLine(i)}");
//}


//foreach (var season in Enum.GetValues<Season>())
//{
//    WriteLine($"{season}");
//    WriteLine($"\tPrev:{season.Previous()}\tNext:{season.Next()}");
//}

//List<(List<int>, List<int>)> data = new()
//{
//    (new List<int> { 1, 5, 10, 8, 12, 4, 5 }, new List<int> { 1, 10, 12, 5 }),
//    (new List<int> { 1, 5, 10, 8, 12, 4, 5, 6 }, new List<int> { 1, 10, 12, 5 }),
//    (new List<int> { 1 }, new List<int> { 1 }),
//    (null, null)
//};

//foreach (var test in data)
//{
//    try
//    {
//        var result = test.Item1.TakeEverySecond();
//        if (Enumerable.SequenceEqual(result, test.Item2))
//        {
//            WriteLine("Passed");
//        }
//    }
//    catch (Exception e)
//    {
//        WriteLine(e.Message);
//    }
//}

//using OtherTests.IEnumerableImplementations;

//var wordsCollection = new WordsCollection(
//    new[]
//    {
//        "quick", "brown", "fox"

//    });

//foreach (var word in wordsCollection)
//{
//    Console.WriteLine(word);
//}

//using OtherTests.EqualityVsEquals;
//new Test().EqualityVsEquals();
//using OtherTests.EqualityVsEquals;
//new StringCompare().Test();
//using OtherTests.EqualityVsEquals;
//new ValueTypeCompare().Test();

//using OtherTests.ShallowVsDeepCopy;
//using static System.Console;

//new TestShallowVsDeep().TestShallowCopy();
//WriteLine(Environment.NewLine);
//new TestShallowVsDeep().TestDeepCopy();

//new ConstVsReadOnlyTesting();

//new RefKeywordDemo();

//GenericTypesMathDemo.Demo();

//using OtherTests.FuncsAndActions;

//new FuncDemo().Demo();

//using OtherTests.LambdaExpressions;

//new LambdaDemo().Demo();

//using OtherTests.IEnumerableTest;


//var words = new WordsCollection("quick", "brown", "fox");
//foreach (var word in words)
//{
//    WriteLine(word);
//}

//words.Add("jumped"); words.Add("over"); words.Add("the"); words.Add("fence");

//foreach (var word in words)
//{
//    WriteLine(word);
//}


List<int> nums = new() { 10, -9, -20, 0, 5, 2, 10, 8, -7, 24, 12, 20 };
NumberFilter numberFilter = new();

WriteLine(nums.DisplayableList());
WriteLine(numberFilter.Filter(FilterBy.Even, nums).DisplayableList());
WriteLine(numberFilter.Filter(FilterBy.Odd, nums).DisplayableList());
WriteLine(numberFilter.Filter(FilterBy.Positive, nums).DisplayableList());


public static class IEnumerableExtensions
{
    public static string DisplayableList(this IEnumerable<int> list, string delimter = ", ")
    {
        return string.Join(delimter, list);
    }
}