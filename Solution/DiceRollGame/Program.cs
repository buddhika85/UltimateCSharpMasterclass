
// play Dice game

using DiceRollGame;

do
{
    Game game = new();
} while (Again());


bool Again()
{
    var answer = ReadAgainInput();
    return answer == 'Y' || answer == 'y';
}

char? ReadAgainInput()
{
    Console.WriteLine("Again [Y] [N] : ");
    return Console.ReadLine()?[0];
}
