using System.Collections;

namespace OtherTests.IEnumerableTest
{
    internal class WordsCollection : IEnumerable
    {
        private readonly List<string> _words = new();

        public WordsCollection(params string[] words)
        {
            foreach (var item in words)
            {
                _words.Add(item);
            }
        }

        public void Add(string word) => _words.Add(word);

        public void Clear() => _words.Clear();

        public bool Remove(string word) => _words.Remove(word);

        public IEnumerator GetEnumerator()
        {
            return new WordEnumerator(_words);
        }
    }
}
