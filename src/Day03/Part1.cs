namespace Day03;

public static class Part1
{
    public static void Run()
    {
        const string fileName = "input.txt";
        var rucksacks = File.ReadAllLines(fileName);

        var prioritySum = 0;

        foreach (var rucksack in rucksacks)
        {
            var compartmentSize = rucksack.Length / 2;
            var firstCompartment = rucksack[..compartmentSize];
            var secondCompartment = rucksack[compartmentSize..];
            var commonCharacter = firstCompartment.Intersect(secondCompartment).First();

            var priorityList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var letterPriority = priorityList.IndexOf(commonCharacter) +1;
            
            prioritySum += letterPriority;
        }
        
        Console.WriteLine(prioritySum);
    }
}