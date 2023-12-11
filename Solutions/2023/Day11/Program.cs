using System.Diagnostics;

var watch = Stopwatch.StartNew();

var solver = new SolverPart1();

//Console.WriteLine($"Solution: {solver.GetSolution("example02.txt")}");
Console.WriteLine($"Solution: {solver.GetSolution("input.txt")}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");