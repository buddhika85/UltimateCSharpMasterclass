using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTest
{
    /*
     Implement the generic Pair type as follows:

It should be a container for two items of the same type.
It should have two properties called First and Second of the type that parameterized this class. 
    Both those properties should be publically gettable but should not be publically settable.
It should have a constructor taking two parameters that sets First and Second properties
This class should expose public ResetFirst and ResetSecond methods that set the First or the Second property to the default values for their type.
     */
    public class Pair<T>
    {
        public T First { get; private set; }
        public T Second { get; private set; }

        public Pair(T first, T second)
        {
            First = first;
            Second = second;
        }

        public void ResetFirst() => First = default;
        public void ResetSecond() => Second = default;
    }
}
