using System.Diagnostics;
using DayXX;

var watch = Stopwatch.StartNew();

var solver1 = new SolverPart1();
Console.WriteLine("Part 1");
Console.WriteLine($"Solution example: {solver1.GetSolution("example.txt")}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");
watch.Restart();
Console.WriteLine($"Solution input: {solver1.GetSolution("input.txt")}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");

var solver2 = new SolverPart2();
Console.WriteLine("Part 2");
Console.WriteLine($"Solution example: {solver2.GetSolution("example.txt")}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");
watch.Restart();
Console.WriteLine($"Solution input: {solver2.GetSolution("input.txt")}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");
