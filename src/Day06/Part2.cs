namespace Day06;

public static class Part2
{
    public static void Run()
    {
        const string fileName = "input.txt";
        var communicationDatastream = File.ReadAllText(fileName);

        // var characterQueue = CreateQueue(communicationDatastream);

        var characterQueue = new Queue<char>(14);
        var startOfPacketMarker = new Dictionary<int, char>();

        for (int i = 0; i < communicationDatastream.Length; i++)
        {
            var character = communicationDatastream[i];
            characterQueue.Enqueue(character);
            if (characterQueue.Count == 15)
            {
                characterQueue.Dequeue();
            }
            // Console.WriteLine(characterQueue.ToArray());
            
            

            if (characterQueue.Distinct().Count() == 14)
            {
                // Console.WriteLine(characterQueue.Distinct().Count());
                startOfPacketMarker.Add(i +1, character);
            }
            
        }
        
        Console.WriteLine(characterQueue.ToArray());
        Console.WriteLine(startOfPacketMarker.First());
    }
}