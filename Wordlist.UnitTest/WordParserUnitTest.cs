using Wordlist.Formatter;
using Wordlist.Models;
using Xunit;

namespace Wordlist.UnitTest
{

    public class WordParserUnitTest
    {
        [Fact]
        public void Should_format_word_concatenation_as_expected()
        {
            // Arrange
            var formatter = new WordFormatter();
            var candidate = new Concatenation("hello", "world", "helloworld");
            // Act
            var result = formatter.Format(candidate);
            // Assert
            Assert.Equal("hello + world => helloworld", result);
        }
    }
}
