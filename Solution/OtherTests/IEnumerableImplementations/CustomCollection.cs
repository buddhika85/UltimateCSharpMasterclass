using System.Collections;

namespace OtherTests.IEnumerableImplementations
{
    public class WordsCollection : IEnumerable
    {
        private readonly string[] _words;

        public WordsCollection(string[] words)
        {
            _words = words;
        }

        public IEnumerator GetEnumerator()
        {
            return new WordsEnumerator(_words);
        }
    }

    public class WordsEnumerator : IEnumerator
    {
        private readonly string[] _words;
        private int _position = -1;

        public WordsEnumerator(string[] words)
        {
            _words = words;
        }
        public bool MoveNext()
        {
            return ++_position < _words.Length;
        }

        public object Current => _words[_position];

        public void Reset()
        {
            _position = -1;
        }
    }
}
