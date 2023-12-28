using System.Diagnostics;
using Day21;

var watch = Stopwatch.StartNew();

var solver = new SolverPart2();

//Console.WriteLine($"Solution: {solver.GetSolution("example.txt", 6)}");
//Console.WriteLine($"Solution: {solver.GetSolution("input.txt", 64)}");
Console.WriteLine($"Solution: {solver.GetSolution("input.txt")}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");
