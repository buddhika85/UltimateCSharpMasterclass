namespace OtherTests
{
    public class DailyAccountState
    {
        public int InitialState { get; }

        public int SumOfOperations { get; }

        public DailyAccountState(
            int initialState,
            int sumOfOperations)
        {
            InitialState = initialState;
            SumOfOperations = sumOfOperations;
        }

        public int EndOfDayState => InitialState + SumOfOperations;

        public string Report =>
            $"Day: {DateTime.Today.Day}, month: {DateTime.Today.Month}, year: {DateTime.Today.Year}, initial state: {InitialState}, end of day state: {EndOfDayState}";
    }
}
