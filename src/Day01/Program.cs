using System.Linq;

const string fileName = "input.txt";

var puzzleInput = File.ReadAllLines(fileName);

// PART 1
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

// PART 2
var caloriesCounted = new List<int>();
var currentCalories = 0;

foreach (var line in puzzleInput)
{
    if (int.TryParse(line, out var calories))
    {
        currentCalories += calories;
    }
    else
    {
        caloriesCounted.Add(currentCalories);
        currentCalories = 0;
    }
}
caloriesCounted.Add(currentCalories);
currentCalories = 0;

var caloriesSorted = caloriesCounted.OrderByDescending(c => c).ToArray();

var result = caloriesSorted[0] + caloriesSorted[1] + caloriesSorted[2]; 

Console.WriteLine(result);