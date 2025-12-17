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

        [Fact]
        public void Should_parse_wordlist_as_expected()
        {
            // Arrange

            var wordlist = new HashSet<string>(StringComparer.Ordinal)
            {
                "al", "bums", "albums",
                "bar", "ely", "barely",
                "be", "foul", "befoul",
                "con", "vex", "convex",
                "here", "by", "hereby",
                "jig", "saw", "jigsaw",
                "tail", "or", "tailor",
                "we", "aver", "weaver"
            };

            var finder = new WordConcatenationFinder();
            var formatter = new WordFormatter();

            // Act
            var results = finder.FindCandidates(wordlist)
                                .Select(formatter.Format)
                                .ToList();

            // Assert
            List<string> expected = new List<string>
            {
              "al + bums => albums",
              "bar + ely => barely",
              "be + foul => befoul",
              "con + vex => convex",
              "here + by => hereby",
              "jig + saw => jigsaw",
              "tail + or => tailor",
              "we + aver => weaver"
            };

            Assert.Equal(expected, results);
        }

        [Fact]
        public void Should_preserve_case_and_find_case_sensitive_concatenation()
        {
            // Arrange
            var wordlist = new HashSet<string>(StringComparer.Ordinal)
            {
                // correct-case parts and combined 6-letter word
                "Go", "ogle", "Google",

                // differently-cased variants to ensure case-sensitivity is enforced
                "go", "Ogle"
            };

            var finder = new WordConcatenationFinder();
            var formatter = new WordFormatter();

            // Act
            var results = finder.FindCandidates(wordlist)
                                .Select(formatter.Format)
                                .ToList();

            // Assert
            Assert.Contains("Go + ogle => Google", results);

            Assert.DoesNotContain("go + Ogle => google", results);
        }
    }
}