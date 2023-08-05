namespace DiceRollGame
{
    public class Game
    {
        private const int MaxTries = 3;
        private readonly Dice _dice = new();

        public Game()
        {
            RollTheDice();
            Play();

            Console.ReadKey();
        }

        private void RollTheDice()
        {
            _dice.Roll();
            Console.WriteLine($"{_dice.Value}\n");
            Console.WriteLine($"Dice Rolled. Guess what number it shows in {MaxTries} tries.");
        }

        private void Play()
        {
            var attempt = 0;
            var isWon = false;
            do
            {
                var answer = ReadNumber("\nEnter a number: ");
                if (IsValidNumber(answer, out var userGuess))
                {
                    if (_dice.Value == userGuess)
                    {
                        isWon = true;
                        Console.WriteLine("You win");
                    }
                    else
                    {
                        // wrong guess or value outside 1-6
                        Console.WriteLine("Wrong number.");
                    }
                    ++attempt;
                }
            } while (attempt < MaxTries && !isWon);

            if (attempt == MaxTries && !isWon)
            {
                Console.WriteLine("You lose");
            }
        }

        private bool IsValidNumber(string? answer, out int guess)
        {
            guess = 0;
            return !string.IsNullOrWhiteSpace(answer) && int.TryParse(answer, out guess); // && guess >= _dice.Min && guess <= _dice.Max;
        }

        private string? ReadNumber(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}
