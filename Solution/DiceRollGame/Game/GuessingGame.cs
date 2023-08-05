using DiceRollGame.UserCommunication;

namespace DiceRollGame.Game
{
    public class GuessingGame
    {
        private readonly int _maxTries;
        private readonly Dice _dice;

        public GuessingGame(int maxTries, int diceSidesCount)
        {
            _maxTries = maxTries;
            _dice = new Dice(diceSidesCount, new Random());
            RollTheDice();
            var result = Play();
            DisplayResult(result);

            Console.ReadKey();
        }

        private void RollTheDice()
        {
            _dice.Roll();
            Console.WriteLine($"Testing - {_dice.Value}\n");
            Console.WriteLine($"Dice Rolled. Guess what number it shows in {_maxTries} tries.");
        }

        private GameResult Play()
        {
            var tryCount = 0;
            do
            {
                var number = ConsoleReader.ReadNumber("\nEnter a number: ");
                if (number == _dice.Value)
                {
                    return GameResult.Victory;
                }
                Console.WriteLine("Wrong number.");
                ++tryCount;
            } while (tryCount < _maxTries);

            return GameResult.Lost;
        }

        private static void DisplayResult(GameResult result)
        {
            var message =
                    result == GameResult.Victory ?
                        "You win" :
                        "You lose :(";
            Console.WriteLine(message);
        }
    }
}
