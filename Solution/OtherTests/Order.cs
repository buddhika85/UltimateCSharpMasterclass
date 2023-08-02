namespace OtherTests
{
    public class Order
    {
        public string Item { get; }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                if (value.Year == DateTime.Now.Year)
                    _date = value;
            }
        }

        public Order(string item, DateTime date)
        {
            Item = item;
            Date = date;
        }
    }
}
