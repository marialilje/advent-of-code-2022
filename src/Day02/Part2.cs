namespace Day02;

public static class Part2
{
    public static void Run()
    {
        const string fileName = "input.txt";
        var strategyGuide = File.ReadAllLines(fileName);
        
        var strategyDictionary = new Dictionary<string, string>()
        {
            {"A", "Rock"},
            {"B", "Paper"},
            {"C", "Scissors"},
            {"X", "Loss"},
            {"Y", "Draw"},
            {"Z", "Win"},
            {"Rock", "1"},
            {"Paper", "2"},
            {"Scissors", "3"},
        };

        var totalScore = 0;

        foreach (var round in strategyGuide)
        {
            var roundInformation = round.Split(" ");
            var elfMove = roundInformation[0];
            var roundResult = roundInformation[1];
            var roundScore = DetermineRoundScore(roundResult);
            var myMove = FindMyMove(elfMove, roundResult);
            var shapeScore = DetermineShapeScore(myMove);
            totalScore += (roundScore + shapeScore);
        }

        string FindMyMove(string elfMove, string roundResult)
        {
            string myMove;

            if (roundResult == "Y")
            {
                myMove = strategyDictionary[elfMove];
            } else if (roundResult == "Z")
            {
                myMove = elfMove switch
                {
                    "A" => strategyDictionary["B"],
                    "B" => strategyDictionary["C"],
                    "C" => strategyDictionary["A"],
                    _ => throw new ArgumentOutOfRangeException(nameof(elfMove), elfMove, null)
                };
            }
            else
            {
                myMove = elfMove switch
                {
                    "A" => strategyDictionary["C"],
                    "B" => strategyDictionary["A"],
                    "C" => strategyDictionary["B"],
                    _ => throw new ArgumentOutOfRangeException(nameof(elfMove), elfMove, null)
                };
            }
            
            return myMove;
        }
        
        int DetermineRoundScore(string roundResult)
        {
            var roundScore = roundResult switch
            {
                "X" => 0,
                "Y" => 3,
                "Z" => 6,
                _ => throw new ArgumentOutOfRangeException(nameof(roundResult), roundResult, null)
            };
            return roundScore;
        }
        
        int DetermineShapeScore(string myMove)
        {
            var moveScore = myMove switch
            {
                "Rock" => 1,
                "Paper" => 2,
                "Scissors" => 3,
                _ => throw new ArgumentOutOfRangeException(nameof(myMove), myMove, null)
            };
            return moveScore;
        }
        
        Console.Write(totalScore);
    }
}