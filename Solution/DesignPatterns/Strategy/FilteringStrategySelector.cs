namespace DesignPatterns.Strategy
{
    public class FilteringStrategySelector
    {
        // dictionary of strategies
        private Dictionary<FilterBy, Func<int, bool>> _filteringStrategies = new() 
        {
            { FilterBy.Even, x => Math.Abs(x % 2) == 0 },
            { FilterBy.Odd, x => Math.Abs(x % 2) == 1 },
            { FilterBy.Positive, x => x > 0 },
        };

        public Func<int, bool> Select(FilterBy filterBy)
        {
            if (_filteringStrategies.ContainsKey(filterBy))
            {
                return _filteringStrategies[filterBy];
            }
            throw new NotSupportedException("Illegal Filter Type");
        }
    }
}
