namespace Day03;

public static class Part2
{
    public static void Run()
    {
        const string fileName = "input.txt";
        var rucksacks = File.ReadAllLines(fileName);

        var prioritySum = 0;
        
        var rucksacksGrouped = rucksacks.Chunk(3);

        foreach (var rucksackGroup in rucksacksGrouped)
        {
            var firstElf = rucksackGroup[0];
            var secondElf = rucksackGroup[1];
            var thirdElf = rucksackGroup[2];

            var firstIntersect = firstElf.Intersect(secondElf);
            var commonCharacter = firstIntersect.Intersect(thirdElf).First();
            
            var priorityList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var letterPriority = priorityList.IndexOf(commonCharacter) +1;
            
            prioritySum += letterPriority;

        }

        Console.WriteLine(prioritySum);
    }
}