using static System.Console;
namespace GenericsTest
{
    public static class ListExtensions
    {
        public static void AddToFront<T>(this List<T> list, T item)
        {
            list.Insert(0, item);
        }

        public static void Display<T>(this List<T> list)
        {
            if (!list.Any())
            {
                WriteLine("No Elements to display");
                return;
            }

            WriteLine($"{string.Join(" | ", list)}{Environment.NewLine}");
        }

        public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> list)
        {
            List<TTarget> resultList = new();
            foreach (var item in list)
            {
                //var result = (TTarget)item;           // does not compile
                var result = (TTarget)Convert.ChangeType(item, typeof(TTarget));
                resultList.Add(result);
            }

            return resultList;
        }
    }

    //class Customer{}

    //class SomeClassOne<Integer>{ }

    //class SomeClassTwo<String>{ }

    //class SomeClassThree<object>{ }

    //class SomeClassThree<Customer> { }

    //class AnotherGenericClass<T> { }
}
