namespace GenericsTest
{
    public class TupleSwapExercise
    {
        public static Tuple<TType2, TType1> SwapTupleItems<TType1, TType2>(Tuple<TType1, TType2> input)
            => Tuple.Create(input.Item2, input.Item1);
    }
}
