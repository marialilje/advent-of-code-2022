namespace Day08;

public static class Part2
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

        var scenicScores = new List<int>();
        var visibleTrees = 0;

        for (int y = 0; y < grid.Length; y++)
        for (int x = 0; x < grid.First().Length; x++)
        {
            var currentTree = grid[y][x];
            var (eastBlocked, westBlocked, southBlocked, northBlocked) = (false, false, false, false);
            var (eastCount, westCount, southCount, northCount) = (0, 0, 0, 0);
            
            for (int east = x + 1; (!eastBlocked && east < grid.Length); east++)
            {
                eastCount++;
                if (grid[y][east] >= currentTree)
                {
                    eastBlocked = true;
                }
                
            }
            
            for (int west = x - 1; (!westBlocked && west >= 0); west--)
            {
                if (grid[y][west] >= currentTree)
                {
                    westBlocked = true;
                }
                westCount++;
            }
            
            for (int south = y + 1; (!southBlocked && south < grid.First().Length); south++)
            {
                if (grid[south][x] >= currentTree)
                {
                    southBlocked = true;
                }
                southCount++;
            }
            
            for (int north = y - 1; (!northBlocked && north >= 0); north--)
            {
                if (grid[north][x] >= currentTree)
                {
                    northBlocked = true;
                }
                northCount++;
            }

            var scenicScore = eastCount * westCount * southCount * northCount;
            scenicScores.Add(scenicScore);
            
        }

        var orderedScenicScores = scenicScores.OrderByDescending(score => score);

        return orderedScenicScores.First().ToString();
    }
}