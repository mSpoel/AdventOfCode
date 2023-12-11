using System.Diagnostics;
using DayXX;

var watch = Stopwatch.StartNew();

var solver = new SolverPart1();

Console.WriteLine($"Solution: {solver.GetSolution("example.txt")}");
//Console.WriteLine($"Solution: {solver.GetSolution("input.txt")}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");
