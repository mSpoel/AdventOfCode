using System.Diagnostics;
using Day24;

var watch = Stopwatch.StartNew();

var solver = new SolverPart1();

//Console.WriteLine($"Solution: {solver.GetSolution("example.txt", 7, 27)}");
Console.WriteLine($"Solution: {solver.GetSolution("input.txt", 200000000000000, 400000000000000)}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");
