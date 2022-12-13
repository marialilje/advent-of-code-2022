namespace Day08;

public static class Part1Attempt2
{
    public static string Run(string[] input)
    {
        var grid = new int[input.Length][];

        for (int y = 0; y < input.Length; y++)
        {
            grid[y] = new int[input[y].Length];
            for (int x = 0; x < input.First().Length; x++)
            {
                
                grid[y][x] = int.Parse(input[y][x].ToString());
            }    
        }
        
        
        
        
        
        
        
        var visibleTrees = 0;

        for (int y = 0; y < grid.Length; y++)
        for (int x = 0; x < grid.First().Length; x++)
        {
            var currentTree = input[y][x];
            var (eastBlocked, westBlocked, southBlocked, northBlocked) = (false, false, false, false);

            for (int east = x + 1; east < input.Length; east++)
            {
                if (input[y][east] >= currentTree)
                {
                    eastBlocked = true;
                }
            }
            
            for (int west = x - 1; west >= 0; west--)
            {
                if (input[y][west] >= currentTree)
                {
                    westBlocked = true;
                }
            }
            
            for (int south = y + 1; south < input.First().Length; south++)
            {
                if (input[south][x] >= currentTree)
                {
                    southBlocked = true;
                }
            }
            
            for (int north = y - 1; north >= 0; north--)
            {
                if (input[north][x] >= currentTree)
                {
                    northBlocked = true;
                }
            }

            var fullyBlocked = eastBlocked && westBlocked && southBlocked && northBlocked;

            if (!fullyBlocked)
            {
                visibleTrees++;
            }

        }
        
        return visibleTrees.ToString();
    }
}