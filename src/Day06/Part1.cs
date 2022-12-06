namespace Day06;

public static class Part1
{
    public static void Run()
    {
        const string fileName = "input.txt";
        var communicationDatastream = File.ReadAllText(fileName);

        // var characterQueue = CreateQueue(communicationDatastream);

        var characterQueue = new Queue<char>(4);
        var startOfPacketMarker = new Dictionary<int, char>();

        for (int i = 0; i < communicationDatastream.Length; i++)
        {
            var character = communicationDatastream[i];
            characterQueue.Enqueue(character);
            if (characterQueue.Count >= 5)
            {
                characterQueue.Dequeue();
            }
            // Console.WriteLine(characterQueue.ToArray());
            
            

            if (characterQueue.Distinct().Count() == 4)
            {
                // Console.WriteLine(characterQueue.Distinct().Count());
                startOfPacketMarker.Add(i +1, character);
            }
            
        }
        
        Console.WriteLine(characterQueue.ToArray());
        Console.WriteLine(startOfPacketMarker.First());
    }

    // public static Queue<char> CreateQueue(string characterCollection)
    // {
    //     var characterQueue = new Queue<char>(4);
    //     
    //     foreach (var character in characterCollection)
    //     {
    //         characterQueue.Enqueue(character);
    //         if (characterQueue.Count >= 5)
    //         {
    //             characterQueue.Dequeue();
    //         }
    //     }
    //
    //     return characterQueue;
    // }
    // public static bool FourUnique(char[] fourCharacters)
    // {
    //
    // }
    
}