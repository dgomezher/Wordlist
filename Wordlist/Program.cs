// See https://aka.ms/new-console-template for more information
using Wordlist;
using Wordlist.Formatter;

Console.WriteLine("Hello, World!");

var absolutePath = "";

if (!File.Exists(absolutePath))
{
    Console.Error.WriteLine($"File not found: {absolutePath}");
    return;
}

IEnumerable<string> ReadWords(string path)
{
    foreach (var line in File.ReadLines(path))
    {
        if (line is null) continue;
        var w = line.Trim();
        if (w.Length == 0) continue;
        yield return w;
    }
}

var words = ReadWords(absolutePath)
    .Select(w => w.ToLowerInvariant())
    .ToHashSet(StringComparer.Ordinal);

if (words.Count == 0)
{
    Console.WriteLine("No words loaded from file.");
}

var finder = new WordConcatenationFinder();
var formatter = new WordFormatter();

IEnumerable<string> FindCandidates(HashSet<string> set)
{
    foreach (var c in finder.FindCandidates(set))
    {
        yield return formatter.Format(c!);
    }
}

var candidates = FindCandidates(words).ToList();

if (candidates.Count > 0)
{
    Console.WriteLine("Candidates:");
    foreach (var candidate in candidates)
    {
        Console.WriteLine(candidate);
    }
}
else
{
    Console.WriteLine("No concatenation candidates found.");
}

Console.WriteLine($"Loaded {words.Count} unique words.");
Console.WriteLine($"Found {candidates.Count} concatenation candidates.");