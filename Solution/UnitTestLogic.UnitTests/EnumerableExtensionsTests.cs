namespace UnitTestLogic.UnitTests
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SumOfEvenNumbers_AddsAllEven_CorrectSum()
        {
            // arrange
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            int expected = 12;

            // act
            int actual = list.SumOfEvenNumbers();

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        [TestCase(0, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(4, 2, 2)]
        [TestCase(8, 1, 2, 6)]
        [TestCase(-6, 1, -4, -2)]
        public void SumOfEvenNumbers_ReturnsEvenSum_ToDifferentInputSizes(int evenSum, params int[] numbers)
        {
            // arrange
            // act
            var actual = numbers.SumOfEvenNumbers();

            // assert
            Assert.That(actual, Is.EqualTo(evenSum));
        }

        [Test]
        [TestCaseSource(nameof(GetNegativeTestCases))]
        public void SumOfEvenNumbers_ReturnsEvenSum_WhenNegativeInputs(IEnumerable<int> numbers, int expected) 
        {
            // arrange
            // act
            int actual = numbers.SumOfEvenNumbers();

            // assert
            Assert.That(actual.Equals(expected));
        }

        // returns a collection of test cases
        private static IEnumerable<object> GetNegativeTestCases()
        {
            return new[] 
            {
                new object[] { new int[] { -1, -2, -3 }, -2 },
                new object[] { new int[] { -1, -2, -3, -4 }, -6 },
                new object[] { new int[] { -1, -2, 2, -3, -4 }, -4 },
                new object[] { new int[] { -1,  -3, }, 0 },
            };
        }

        [Test]
        public void SumOfEvenNumbers_ThrowsNullException_ToNullInput()
        {
            // arrange 
            IEnumerable<int> numbers = null;
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => numbers!.SumOfEvenNumbers());
        }
    }
}