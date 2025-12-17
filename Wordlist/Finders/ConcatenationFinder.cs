using Wordlist.Models;

namespace Wordlist.Finders
{
    public sealed class WordConcatenationFinder : ICandidateWordsFinder
    {
        public IEnumerable<Concatenation> FindCandidates(ISet<string> words)
        {
            throw new NotImplementedException();
        }
    }
}
