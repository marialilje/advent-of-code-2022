namespace Day06;

public static class Part1
{
    public static void Run()
    {
        const string fileName = "input.txt";
        var communicationDatastream = File.ReadAllText(fileName);
        
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

            if (characterQueue.Distinct().Count() == 4)
            {
                startOfPacketMarker.Add(i +1, character);
            }
        }
        Console.WriteLine(startOfPacketMarker.First());
    }
}