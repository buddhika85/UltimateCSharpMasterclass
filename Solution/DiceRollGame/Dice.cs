namespace DiceRollGame
{
    public class Dice
    {
        public readonly int Min = 1;
        public readonly int Max = 6;
        public int Value { get; private set; }
        public void Roll()
        {
            Value = new Random().Next(Min, Max + 1);
        }
    }
}
