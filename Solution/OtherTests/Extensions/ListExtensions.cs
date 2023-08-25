namespace OtherTests.Extensions
{
    public static class ListExtensions
    {
        public static List<int> TakeEverySecond(this List<int> list)
        {
            if (list == null)
                throw new NullReferenceException("list cannot be null");

            var listFiltered = new List<int>();
            for (var i = 0; i < list.Count; i += 2)
            {
                listFiltered.Add(list[i]);
            }
            return listFiltered;
        }
    }
}
