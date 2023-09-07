namespace OtherTests.ExceptionsEx
{
    public static class ExceptionsDivisionExercise
    {
        public static int DivideNumbers(int a, int b)
        {
            var result = 0;
            try
            {
                result = a / b;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Division by zero.");
            }
            finally
            {
                Console.WriteLine("The DivideNumbers method ends.");
            }
            return result;
        }
    }

    public class Exercise
    {
    }
}
