namespace OtherTests.Extensions
{
    public static class SeasonExtensions
    {
        public static Season Next(this Season season)
        {
            var currentInt = (int)season;
            var nextInt = (++currentInt % Enum.GetValues<Season>().Length);
            return (Season)nextInt;
        }

        public static Season Previous(this Season season)
        {
            var length = Enum.GetValues<Season>().Length;
            var currentInt = (int)season;
            // if 0 get last index, or decrease by one
            var prevInt = currentInt == 0 ? length - 1 : --currentInt;
            return (Season)prevInt;
        }
    }
}
