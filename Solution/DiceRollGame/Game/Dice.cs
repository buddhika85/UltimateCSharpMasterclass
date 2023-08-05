namespace DiceRollGame.Game
{
    public class Dice
    {
        private readonly Random _random;
        private readonly int _sidesCount;
        public int Value { get; private set; }

        public Dice(int sidesCount, Random random)
        {
            _random = random;
            _sidesCount = sidesCount;
        }

        public void Roll() =>
            Value = _random.Next(1, _sidesCount + 1);     // inclusive lower bound, exclusive upper bound

        public override string ToString()
        {
            return $"This is a dice with {_sidesCount} sides";
        }
    }
}
