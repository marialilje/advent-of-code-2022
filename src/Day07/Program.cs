using Day07;
using File = System.IO.File;

var fileName = File.ReadAllText("input.txt");

Console.WriteLine($"Part 1: {(Part1.Run(fileName))}");
Console.WriteLine($"Part 2: {(Part2.Run(fileName))}");