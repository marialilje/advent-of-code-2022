namespace Day08;

public static class Part1
{
    public static string Run(string[] input)
    {
        int visibleTrees;
        
        var treeDictionary = new Dictionary<string, Tree>();

        for (var y = 0; y < input.Length; y++)
        {
            for (var x = 0; x < input.First().Length; x++)
            {
                var currentIterator = y + x.ToString();
                var currentTree = input[y][x];
                var isVisible = CheckIsVisible(currentTree);

                bool CheckIsVisible(char tree)
                {
                    var treeHeight = int.Parse(tree.ToString());

                    var (eastVisible, westVisible, southVisible, northVisible) = (true, true, true, true);

                    for (var eastDirection = x + 1; eastDirection < input.First().Length; eastDirection++)
                    {
                        if (int.Parse(input[y][eastDirection].ToString()) >= treeHeight)
                        {
                            eastVisible = false;
                        }
                    }
                    
                    for (int westDirection = x - 1; westDirection >= 0; westDirection--)
                    {
                        if (int.Parse(input[y][westDirection].ToString()) >= treeHeight)
                        {
                            westVisible = false;
                        }
                    }
                    
                    for (int southDirection = y + 1; southDirection < input.Length; southDirection++)
                    {
                        if (int.Parse(input[southDirection][x].ToString()) >= treeHeight)
                        {
                            southVisible = false;
                        }
                    }
                    
                    for (int northDirection = y - 1; northDirection >= 0; northDirection--)
                    {
                        if (int.Parse(input[northDirection][x].ToString()) >= treeHeight)
                        {
                            northVisible = false;
                        }
                    }
                    
                    return eastVisible || westVisible || southVisible || northVisible;
                }

                treeDictionary[currentIterator] = new Tree
                {
                    Heigth = currentTree,
                    Visible = isVisible
                };


                // foreach (var key in treeDictionary.Keys)
                // {
                //     if (key.StartsWith("0") || key.Last() == '0' || key.Last() == (input.First().Length - 1) || key.StartsWith(
                //             (input.Length - 1).ToString()))
                //     {
                //         treeDictionary[key].Visible = true;
                //     }
                //     // Console.WriteLine(key);
                //     // Console.WriteLine(key.Last());
                //     
                // }
                // var outerTrees = input.First().Length + input.Last().Length + ((input.Length - 2) * 2);
                // treeDictionary[0i]
                
                // Console.WriteLine(treeDictionary[currentIterator].Visible);

            }
        }

        visibleTrees = treeDictionary.Values.Count(tree => tree.Visible);
        
        return visibleTrees.ToString();
    }

    public class Tree
    {
        public char Heigth { get; set; }
        public bool Visible { get; set; }
    }
}