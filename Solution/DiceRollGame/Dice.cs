namespace DiceRollGame
{
    public class Dice
    {
        private const int Min = 1;
        private const int Max = 6;
        public int Value { get; private set; }
        public void Roll()
        {
            Value = new Random().Next(Min, Max + 1);
        }
    }
}
