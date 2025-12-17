using Wordlist.Finders;
using Wordlist.Models;

namespace Wordlist
{
    public sealed class WordConcatenationFinder : ICandidateWordsFinder
    {
        public IEnumerable<Concatenation> FindCandidates(ISet<string> words)
        {
            ArgumentNullException.ThrowIfNull(words);

            var set = new HashSet<string>(words, StringComparer.Ordinal);

            var visited = new HashSet<string>();

            foreach (var word in set)
            {
                if (word is null) continue;
                if (word.Length != 6) continue;

                for (int charCount = 1; charCount <= 5; charCount++)
                {
                    var left = word.Substring(0, charCount);
                    var right = word.Substring(charCount);
                    if (set.Contains(left) && set.Contains(right))
                    {
                        if (visited.Add(word))
                        {
                            yield return new Concatenation(left, right, word);
                        }
                        break;
                    }
                }
            }
        }
    }
}
