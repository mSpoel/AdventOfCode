using System.Diagnostics;
using Day21;

var watch = Stopwatch.StartNew();

var solver = new SolverPart1();

//Console.WriteLine($"Solution: {solver.GetSolution("example.txt", 6)}");
Console.WriteLine($"Solution: {solver.GetSolution("input.txt", 64)}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");
