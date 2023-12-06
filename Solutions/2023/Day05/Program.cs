﻿using System.Diagnostics;

var watch = Stopwatch.StartNew();

var solver = new SolverPart2();

//Console.WriteLine($"Solution: {solver.GetSolution("example.txt")}");
Console.WriteLine($"Solution: {solver.GetSolution("input.txt")}");
Console.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}ms");