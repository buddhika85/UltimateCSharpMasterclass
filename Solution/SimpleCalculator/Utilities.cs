namespace SimpleCalculator
{
    public static class Utilities
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static int ReadInt(string question)
        {
            DisplayMessage(question);
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return int.Parse(input.Trim());
            return 0;
        }

        public static char ReadUpperChar(string question)
        {
            DisplayMessage(question);
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input.ToUpper().Trim()[0];
            return 'e'; // denotes error
        }
    }
}
