namespace DiceRollGame.UserCommunication
{
    public static class ConsoleReader
    {
        public static string? ReadAnswer(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static int ReadNumber(string question)
        {
            int numberInput;
            do
            {
                Console.WriteLine(question);

            } while (!int.TryParse(Console.ReadLine(), out numberInput));
            return numberInput;
        }
    }
}
