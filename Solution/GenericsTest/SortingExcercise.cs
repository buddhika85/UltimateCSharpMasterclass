using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTest
{
    public class SortingExcercise
    {
        
        public SortingExcercise()
        {
            // John Smith, Anna Smith, Kenji Narasaki, John Watson
            SortedList<FullName> list = new(
                new FullName[]
                {
                new FullName { FirstName = "John", LastName = "Smith"},
                new FullName { FirstName = "Anna", LastName = "Smith"},
                new FullName { FirstName = "Kenji", LastName = "Narasaki"},
                new FullName { FirstName = "John", LastName = "Watson"}
                }
            );


            // Kenji Narasaki, Anna Smith, John Smith, John Watson
            foreach (var item in list.Items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class SortedList<T> where T : IComparable<T>
    {
        public IEnumerable<T> Items { get; }

        public SortedList(IEnumerable<T> items)
        {
            var asList = items.ToList();
            asList.Sort();
            Items = asList;
        }
    }

    public class FullName : IComparable<FullName>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        // The names stored in the Items collection should be sorted
        // first by LastName, then by FirstName.
        public int CompareTo(FullName? other)
        {
            if (other == null) return 1;
            if (other == this) return 0;

           
            if (LastName.CompareTo(other.LastName) == 0)                            
                return FirstName.CompareTo(other.FirstName);            
            else 
                return LastName.CompareTo(other.LastName);
        }

        public override string ToString() => $"{FirstName} {LastName}";

        //your code hoes here
    }
}
