
using DiceRollGame.Game;



const int maxTries = 3;
const int diceSidesCount = 6;
do
{
    GuessingGame guessingGame = new(maxTries, diceSidesCount);
} while (Again());


bool Again()
{
    var answer = ReadAgainInput();
    return answer == 'Y' || answer == 'y';
}

char? ReadAgainInput()
{
    Console.WriteLine("\nAgain [Y] [N] : ");
    return Console.ReadLine()?[0];
}
