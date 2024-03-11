using System.Collections;

namespace OtherTests.IEnumerableTest
{
    internal class WordEnumerator : IEnumerator
    {
        private readonly List<string> _words;
        private int index = -1;
        private List<string> words;

        public WordEnumerator(List<string> words)
        {
            _words = words;
        }

        object IEnumerator.Current => _words[index];

        public bool MoveNext()
        {
            return ++index < _words.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}