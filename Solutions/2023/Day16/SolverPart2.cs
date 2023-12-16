using System.Collections.Concurrent;
using Utilities;

namespace Day16
{
    internal class SolverPart2
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var gridBuilder = new GridBuilder();
            foreach (var line in lines)
            {
                gridBuilder.Add(line);
            }

            var grid = gridBuilder.Build();
            var beamTracer = new BeamTracer(grid, false);

            Task<int> resultRightTask = Task.Run(() => GoRight(grid, beamTracer));
            Task<int> resultLeftTask = Task.Run(() => GoLeft(grid, beamTracer));
            Task<int> resultUpTask = Task.Run(() => GoUp(grid, beamTracer));
            Task<int> resultDownTask = Task.Run(() => GoDown(grid, beamTracer));

            Task.WaitAll(resultRightTask, resultLeftTask, resultUpTask, resultDownTask);

            int resultRight = resultRightTask.Result;
            int resultLeft = resultLeftTask.Result;
            int resultUp = resultUpTask.Result;
            int resultDown = resultDownTask.Result;

            return Math.Max(Math.Max(resultRight, resultLeft), Math.Max(resultUp, resultDown));
        }

        private int GoUp(Grid grid, BeamTracer beamTracer)
        {
            ConcurrentBag<int> results = [];
            var row = grid.NumberOfRows - 1;
            Parallel.For(0, grid.NumberOfRows, i =>
            {
                var temp = beamTracer.NumberOfPointsAffectedByBeam(row, i, [Direction.Up]);
                results.Add(temp);

                Console.WriteLine($"Row {row} column {i}: {temp}");
            });

            return results.Max();
        }

        private int GoDown(Grid grid, BeamTracer beamTracer)
        {
            ConcurrentBag<int> results = [];
            Parallel.For(0, grid.NumberOfColumns, i =>
            {
                var temp = beamTracer.NumberOfPointsAffectedByBeam(0, i, [Direction.Down]);
                results.Add(temp);

                Console.WriteLine($"Row 0 column {i}: {temp}");
            });

            return results.Max();
        }

        private int GoLeft(Grid grid, BeamTracer beamTracer)
        {
            ConcurrentBag<int> results = [];
            var column = grid.NumberOfColumns - 1;
            Parallel.For(0, grid.NumberOfRows, i =>
            {
                var temp = beamTracer.NumberOfPointsAffectedByBeam(i, column, [Direction.Left]);
                results.Add(temp);

                Console.WriteLine($"Row {i} column {column}: {temp}");
            });

            return results.Max();
        }

        private static int GoRight(Grid grid, BeamTracer beamTracer)
        {
            ConcurrentBag<int> results = [];

            Parallel.For(0, grid.NumberOfRows, i =>
            {
                var temp = beamTracer.NumberOfPointsAffectedByBeam(i, 0, [Direction.Right]);
                results.Add(temp);
                Console.WriteLine($"Row {i} column 0: {temp}");
            });

            return results.Max();
        }
    }
}
