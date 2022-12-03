const string fileName = "input.txt";

const int rock = 1;
const int paper = 2;
const int scissors = 3;

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

int checkChoiceScore(string s)
{
    var result = s switch
    {
        "X" => rock,
        "Y" => paper,
        "Z" => scissors,
        _ => 0
    };
    return result;
}

int determineScore(string round)
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
    
    var choiceScore = checkChoiceScore(myMove);
    roundScore += choiceScore;

    return roundScore;
}

var totalScore = strategyGuide.Sum(determineScore);

Console.WriteLine(totalScore);