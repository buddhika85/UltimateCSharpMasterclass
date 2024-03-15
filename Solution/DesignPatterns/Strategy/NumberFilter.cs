using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    public class NumberFilter
    {
        // strategy gets passed from outside
        public IEnumerable<int> Filter(Func<int, bool> strategy, IEnumerable<int> numbers)
        {
            return numbers.Where(x => strategy(x));
        }
    }
}
