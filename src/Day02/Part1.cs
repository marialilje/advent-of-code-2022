namespace Day02;

public static class Part1
{
    
    public static void Run()
    {
        const string fileName = "input.txt";

        const int rockScore = 1;
        const int paperScore = 2;
        const int scissorsScore = 3;

        const int lossScore = 0;
        const int drawScore = 3;
        const int winScore = 6;

        var movesDictionary = new Dictionary<string, string>()
        {
            {"A", "Rock"},
            {"B", "Paper"},
            {"C", "Scissors"},
            {"X", "Rock"},
            {"Y", "Paper"},
            {"Z", "Scissors"}
        };

        var strategyGuide = File.ReadAllLines(fileName);

        int CheckChoiceScore(string myMove)
        {
            var result = myMove switch
            {
                "X" => rockScore,
                "Y" => paperScore,
                "Z" => scissorsScore,
                _ => throw new ArgumentOutOfRangeException(nameof(myMove), myMove, null)
            };
            return result;
        }

        int DetermineScore(string round)
        {
            var roundScore = 0;
            var moves = round.Split(" ");
            var elfMove = moves[0];
            var myMove = moves[1];
            var draw = movesDictionary[elfMove] == movesDictionary[myMove];
            var win = (myMove == "X" && elfMove == "C") || (myMove == "Y" && elfMove == "A") || (myMove == "Z" && elfMove == "B");

            if (draw)
            {
                roundScore += drawScore;
            }
            else if (win)
            {
                roundScore += winScore;
            }
            else
            {
                roundScore += lossScore;
            }
    
            var choiceScore = CheckChoiceScore(myMove);
            roundScore += choiceScore;

            return roundScore;
        }

        var totalScore = strategyGuide.Sum(DetermineScore);

        Console.WriteLine(totalScore);
    }
}