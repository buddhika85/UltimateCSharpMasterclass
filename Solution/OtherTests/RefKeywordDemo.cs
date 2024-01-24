namespace OtherTests
{
    public class RefKeywordDemo
    {
        public RefKeywordDemo()
        {
            int x = 10;
            AddOne(x);
            Console.WriteLine(x);


            AddOne(ref x);
            Console.WriteLine(x);

            string input = "10";
            bool wasPassed = TryPassToInt(input, out x);
            if (wasPassed)
            {
                Console.WriteLine($"Success: {x}");
            }
            else
            {
                Console.WriteLine($"Invalid number: {input}");
            }
        }

        private void AddOne(int x) => ++x;

        private void AddOne(ref int x) => ++x;


        private bool TryPassToInt(string input, out int result)
        {
            try
            {
                result = int.Parse(input);
                return true;
            }
            catch (Exception e)
            {
                result = 0;
                return false;
            }
        }
    }
}
