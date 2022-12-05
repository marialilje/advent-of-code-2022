namespace Day05;

public static class Part2
{
    public static void Run()
    {
        const string fileName = "input.txt";
        var crateInformation = File.ReadAllText(fileName);

        var startIndex = 2+ crateInformation.IndexOf("9");
        var crateMap = crateInformation.Substring(0, startIndex);
        var moveInstructions = crateInformation.Substring(startIndex);
        
        var stacks = CreateStacks(crateMap);
        var instructions = CreateInstructions(moveInstructions);
        
        ProcessInstructions(stacks, instructions);
    }
    public static Dictionary<string, Stack<char>> CreateStacks(string stacksText)
    {
        var stacksArray = stacksText.ReplaceLineEndings(Environment.NewLine).Split(Environment.NewLine).Reverse().Skip(1);
        
        var crateStacks = new Dictionary<string, Stack<char>>()
        {
            {"1", new Stack<char>()},
            {"2", new Stack<char>()},
            {"3", new Stack<char>()},
            {"4", new Stack<char>()},
            {"5", new Stack<char>()},
            {"6", new Stack<char>()},
            {"7", new Stack<char>()},
            {"8", new Stack<char>()},
            {"9", new Stack<char>()}
        };
        

        foreach (var line in stacksArray)
        {
            for (int i = 1, j = 1; i < 10 && j < 34; i++, j+=4)
            {
                if (line[j] != ' ')
                {
                    crateStacks[i.ToString()].Push(line[j]);
                }
            }
        }
        return crateStacks;
    }

    public static List<Instructions> CreateInstructions(string instructionsText)
    {
        var instructionsArray = instructionsText.ReplaceLineEndings(Environment.NewLine).Split(Environment.NewLine).Skip(2);
        var instructionsList = new List<Instructions>();

        foreach (var line in instructionsArray)
        {
           
                var instructions = line.Split(" ");
                instructionsList.Add(new Instructions
                {
                    NumberOfCrates = int.Parse(instructions[1]),
                    From = instructions[3],
                    To = instructions[5]
                }
                );
            
        }

        return instructionsList;
    }

    public static void ProcessInstructions(Dictionary<string, Stack<char>> stacks, List<Instructions> instructions)
    {
        
        foreach (var instruction in instructions)
        {
            string removedBox = null;
            for (int i = 1; i <= instruction.NumberOfCrates; i++)
            {
                removedBox += stacks[instruction.From].Pop();
            }
            for (int i = removedBox.Length -1 ; i >= 0; i--)
            {
                stacks[instruction.To].Push(removedBox[i]);
            }
        }
        string result = "";

        for (int i = 1; i <= 9; i++)
        {
            result += stacks[i.ToString()].Peek();
        }
        
        Console.WriteLine(result);
    }
}


