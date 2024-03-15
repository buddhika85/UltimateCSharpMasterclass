using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherTests.FuncsAndActions.Practise
{
    public class NumberFilter
    {
        public IEnumerable<int> Filter(FilterBy filterBy, IEnumerable<int> numbers)
        {
            switch (filterBy)
            {
                case FilterBy.Odd:
                    return FilterNumbers(numbers, (x => Math.Abs(x % 2) == 1));
                case FilterBy.Even:
                    return FilterNumbers(numbers, (x => x % 2 == 0));
                case FilterBy.Positive:
                    return FilterNumbers(numbers, (x => x > 0));
                default:
                    return Enumerable.Empty<int>();
            }
        }

        private IEnumerable<int> FilterNumbers(IEnumerable<int> numbers, Func<int, bool> predicate)
        {
            return numbers.Where(x => predicate(x));
        }
    }
}
