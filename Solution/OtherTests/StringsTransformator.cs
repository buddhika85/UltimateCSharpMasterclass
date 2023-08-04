namespace OtherTests
{
    public static class StringsTransformator
    {
        public static string TransformSeparators(
            string input,
            string originalSeparator,
            string targetSeparator)
        {
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(originalSeparator) || string.IsNullOrWhiteSpace(targetSeparator))
                return input;
            return input.Replace(originalSeparator, targetSeparator);
        }
    }
}
