using Wordlist.Models;

namespace Wordlist.Formatter
{
    public interface IResultFormatter
    {
        string Format(Concatenation result);
    }
}
