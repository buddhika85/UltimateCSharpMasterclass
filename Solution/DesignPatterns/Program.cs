using DesignPatterns.Strategy;
using static System.Console;

WriteLine("--- Design Patterns ---");

//SingletonDemo.Demo();

//BuilderDemo.Demo();

//AdapterDemo.Test();

//BridgeDemo.Demo();


//using DesignPatterns.Strategy;

//StaticFactoryMethodDemo.Demo();


List<int> nums = new() { 10, -9, -20, 0, 5, 2, 10, 8, -7, 24, 12, 20 };
NumberFilter numberFilter = new();

WriteLine(nums.DisplayableList());
FilteringStrategySelector filteringStrategySelector = new ();

WriteLine(numberFilter.Filter(filteringStrategySelector.Select(FilterBy.Positive), nums).DisplayableList());
WriteLine(numberFilter.Filter(filteringStrategySelector.Select(FilterBy.Odd), nums).DisplayableList());
WriteLine(numberFilter.Filter(filteringStrategySelector.Select(FilterBy.Even), nums).DisplayableList());


public static class IEnumerableExtensions
{
    public static string DisplayableList(this IEnumerable<int> list, string delimter = ", ")
    {
        return string.Join(delimter, list);
    }
}