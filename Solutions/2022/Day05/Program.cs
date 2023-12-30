using System.Diagnostics;
using Day05;

var watch = Stopwatch.StartNew();

Console.WriteLine("Part 1");
Console.WriteLine($"Solution example: {SolverPart1.GetSolution("example.txt", 3)}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");
watch.Restart();
Console.WriteLine($"Solution input: {SolverPart1.GetSolution("input.txt", 9)}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");

Console.WriteLine("Part 2");
Console.WriteLine($"Solution example: {SolverPart2.GetSolution("example.txt", 3)}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");
watch.Restart();
Console.WriteLine($"Solution input: {SolverPart2.GetSolution("input.txt", 9)}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");

