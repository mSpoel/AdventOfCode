using System.Diagnostics;
using Day07;

var watch = Stopwatch.StartNew();

// not feeling to well, so I'm going to use the same code as in part 1 and adjust it a bit
var solver = new SolverPart1();

//Console.WriteLine($"Solution: {solver.GetSolution("example.txt")}");
Console.WriteLine($"Solution: {solver.GetSolution("input.txt")}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");