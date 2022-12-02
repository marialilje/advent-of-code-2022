
const string fileName = "input.txt";

var puzzleInput = File.ReadAllLines(fileName);
var largestCalorie = 0;
var currentElfCalories = 0;

foreach (var line in puzzleInput)
{
    if (int.TryParse(line, out var calories))
    {
        currentElfCalories += calories;
    }
    else
    {
        if (currentElfCalories > largestCalorie)
        {
            largestCalorie = currentElfCalories;
        }
        currentElfCalories = 0;
    }
}

if (currentElfCalories > largestCalorie)
{
    largestCalorie = currentElfCalories;
}

Console.WriteLine(largestCalorie);
