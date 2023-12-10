using System.Diagnostics;
using Day10;

var watch = Stopwatch.StartNew();

var solver = new SolverPart2();

Console.WriteLine($"Solution: {solver.GetSolution("example02.txt")}");
Console.WriteLine($"Solution: {solver.GetSolution("input.txt")}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");