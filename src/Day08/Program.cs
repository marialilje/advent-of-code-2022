using Day08;

var fileName = File.ReadAllLines("input.txt");

Console.WriteLine($"Part 1: {(Part1.Run(fileName))}"); //1736

Console.WriteLine($"Part1 attempt 2: {Part1Attempt2.Run(fileName)}");
Console.WriteLine($"Part 2: {(Part2.Run(fileName))}"); //268800