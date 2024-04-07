namespace UnitTestLogic.UnitTests
{
    [TestFixture]
    public class FibonacciGeneratorTests
    {
        private FibonacciGenerator _fibonacciGenerator;

        [SetUp]
        public void Setup()
        {
            _fibonacciGenerator = new();
        }


        [Test]
        [TestCase(0)]
        public void FibSequence_ThrowsArgEx_InputLessMinValidNum(int minValidNum)
        {
            // arrange 
            // act
            // assert
            Assert.Throws<ArgumentException>(() =>
                _fibonacciGenerator.FibSequence(minValidNum - 1));
        }

        [Test]
        [TestCase(46)]
        public void FibSequence_ThrowsArgEx_InputGreaterThanMaxValidNum(int maxValidNum)
        {
            // arrange 
            // act
            // assert
            Assert.Throws<ArgumentException>(()
                => _fibonacciGenerator.FibSequence(maxValidNum + 1));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-100)]
        [TestCase(47)]
        [TestCase(48)]
        [TestCase(100)]
        public void FibSequence_ThrowsArgEx_ForInputInvalidNum(int invalidNum)
        {
            // arrange 
            // act
            // assert
            Assert.Throws<ArgumentException>(() =>
                _fibonacciGenerator.FibSequence(invalidNum));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(45)]
        [TestCase(46)]
        public void FibSequence_ReturnsValidCollection_OnValidInput(int count)
        {
            // arrange             
            // act
            var actual = _fibonacciGenerator.FibSequence(count);
            // assert   
            Assert.That(actual, Is.TypeOf<List<int>>());
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(45)]
        [TestCase(46)]
        public void FibSequence_DoesNotThrowExceptions_OnValidInput(int count)
        {
            // arrange             
            // act
            var actual = _fibonacciGenerator.FibSequence(4);
            // assert   
            Assert.DoesNotThrow(() => _fibonacciGenerator.FibSequence(count));
        }

        [Test]
        public void FibSequence_ReturnsEmptyCollection_InputZero()
        {
            // arrange 
            var expected = Enumerable.AsEnumerable(new int[] { });
            // act
            var actual = _fibonacciGenerator.FibSequence(0);
            // assert   
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void FibSequence_ReturnsValidSequence_InputFour()
        {
            // arrange 
            var expected = Enumerable.AsEnumerable(new int[] { 0, 1, 1, 2 });
            // act
            var actual = _fibonacciGenerator.FibSequence(4);
            // assert   
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        // write some test cases to test valid long fibonacci sequences
        [Test]
        [TestCase(0, new int[0] { })]
        [TestCase(1, new int[1] { 0 })]
        [TestCase(2, new int[2] { 0, 1 })]
        [TestCase(3, new int[3] { 0, 1, 1 })]
        [TestCase(4, new int[4] { 0, 1, 1, 2 })]
        [TestCase(5, new int[5] { 0, 1, 1, 2, 3 })]
        [TestCase(6, new int[6] { 0, 1, 1, 2, 3, 5 })]
        [TestCase(7, new int[7] { 0, 1, 1, 2, 3, 5, 8 })]
        [TestCase(8, new int[8] { 0, 1, 1, 2, 3, 5, 8, 13 })]
        public void FibSequence_ReturnsValidSequence_DifferentInputs(int count, int[] extepectedSequence)
        {
            // arrange
            // act
            var actual = _fibonacciGenerator.FibSequence(count);

            // assert
            Assert.That(actual, Is.EquivalentTo(extepectedSequence));
        }
    }
}
