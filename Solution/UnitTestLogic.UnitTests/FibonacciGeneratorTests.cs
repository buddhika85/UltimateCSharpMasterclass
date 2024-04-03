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
    }
}
