using Wordlist.Models;

namespace Wordlist.Formatter
{
    public sealed class WordFormatter : IResultFormatter
    {
        public string Format(Concatenation concatenation) => $"{concatenation.Left} + {concatenation.Right} => {concatenation.Combined}";
    }
}
