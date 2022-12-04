namespace Day04;

public static class Part2
{
    public static void Run()
    {
        const string fileName = "input.txt";
        var cleaningAreas = File.ReadAllLines(fileName);

        var numberOverlapping = 0;

        foreach (var cleaningArea in cleaningAreas)
        {
            var elfPair = cleaningArea.Split(",");
            var elfOne = elfPair[0].Split("-");
            var elfTwo = elfPair[1].Split("-");

            var elfOneStart = int.Parse(elfOne[0]);
            var elfOneStop = int.Parse(elfOne[1]);
            var elfTwoStart = int.Parse(elfTwo[0]);
            var elfTwoStop = int.Parse(elfTwo[1]);
            
            var elfOverlapping = false;

            if (elfOneStart >= elfTwoStart)
            {
                if (elfOneStop <= elfTwoStop)
                {
                    elfOverlapping = true;
                } 
                else if (elfOneStart <= elfTwoStop)
                {
                    elfOverlapping = true;
                }
            }
            if (elfTwoStart >= elfOneStart)
            {
                if (elfTwoStop <= elfOneStop)
                {
                    elfOverlapping = true;
                }
                else if (elfTwoStart <= elfOneStop)
                {
                    elfOverlapping = true;
                }
            }

            if (elfOverlapping)
            {
                numberOverlapping++;
            }


        }
        
        Console.WriteLine(numberOverlapping);
    }
}