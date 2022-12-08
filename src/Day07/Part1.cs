using System.Text.RegularExpressions;

namespace Day07;

public static class Part1
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

        return results.Values.Where(size => size <= 100000).Sum().ToString();
    }
}

record Command(string Text, List<string> Output);

record File(string Name, long Size);

record Directory(string Path)
{
    private long? _size;

    public Directory? Parent { get; init; }
    public List<File> Files { get; } = new();
    public Dictionary<string, Directory> Directories { get; } = new();

    public void Ls(List<string> lsOutput)
    {
        foreach (var lsLine in lsOutput)
        {
            var dirMatch = Regex.Match(lsLine, @"^dir (.*)");
            if (dirMatch.Success)
            {
                var targetDir = dirMatch.Groups[1].Value;
                Directories[targetDir] = new Directory($"{Path.TrimEnd('/')}/{targetDir}")
                {
                    Parent = this
                };
            }
            else
            {
                var fileParts = lsLine.Split(' ');
                Files.Add(new File(fileParts[1], long.Parse(fileParts[0])));
            }
        }
    }

    public Directory Cd(string cdTarget)
    {
        if (cdTarget == "..")
            return Parent!;
        
        return cdTarget.StartsWith('/')
            ? new Directory(cdTarget)
            : Directories[cdTarget];
    }

    public long Size => _size ??= Files.Sum(f => f.Size) + Directories.Values.Sum(d => d.Size);

    public void MeasureSizes(Dictionary<string,long> results)
    {
        results[Path] = Size;
        foreach (var subDirectory in Directories.Values)
            subDirectory.MeasureSizes(results);
    }
}