using System.Text.RegularExpressions;

namespace Day07;

public static class Part2
{
    public static string Run(string input)
    {
        var commands = input
            .Split("$ ", StringSplitOptions.RemoveEmptyEntries)
            .Select(text =>
            {
                var commandLines = text
                    .ReplaceLineEndings(Environment.NewLine)
                    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                return new Command(commandLines[0], commandLines.Skip(1).ToList());
            })
            .ToArray();

        var rootDirectory = new Directory("/");
        var directory = rootDirectory;

        foreach (var command in commands.Skip(1))
        {
            var cdMatch = Regex.Match(command.Text, @"^cd (.*)");
            if (cdMatch.Success)
            {
                var cdTarget = cdMatch.Groups[1].Value;
                directory = directory.Cd(cdTarget);
            }
            else if (command.Text == "ls")
                directory.Ls(command.Output);
        }

        var results = new Dictionary<string, long>();
        rootDirectory.MeasureSizes(results);

        var orderedResults = results.Values.OrderByDescending(n => n);
        var rootSize = orderedResults.First();
        var freeSpace = 70000000 - rootSize;
        var amountToFreeUp = 30000000 - freeSpace;
        
        var filteredResult = orderedResults.Where(size => size >= amountToFreeUp);

        var closest = filteredResult.MinBy(v => Math.Abs(v - amountToFreeUp));
        // Console.WriteLine(filteredResult.First());

        return closest.ToString();
    }
}