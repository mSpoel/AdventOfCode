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
            int result = 0;
            var row = grid.NumberOfRows - 1;
            for (int i = 0; i < grid.NumberOfRows; i++)
            {
                var temp = beamTracer.NumberOfPointsAffectedByBeam(row, i, [Direction.Up]);
                result = Math.Max(result, temp);
                Console.WriteLine($"Row {row} column {i}: {temp} Result: {result}");
            }

            return result;
        }

        private int GoDown(Grid grid, BeamTracer beamTracer)
        {
            int result = 0;
            for (int i = 0; i < grid.NumberOfColumns; i++)
            {
                var temp = beamTracer.NumberOfPointsAffectedByBeam(0, i, [Direction.Down]);
                result = Math.Max(result, temp);
                Console.WriteLine($"Row 0 column {i}: {temp} Result: {result}");
            }
            return result;
        }

        private int GoLeft(Grid grid, BeamTracer beamTracer)
        {
            var result = 0;
            var column = grid.NumberOfColumns - 1;
            for (int i = 0; i < grid.NumberOfRows; i++)
            {
                var temp = beamTracer.NumberOfPointsAffectedByBeam(i, column, [Direction.Left]);
                result = Math.Max(result, temp);
                Console.WriteLine($"Row {i} column {column}: {temp} Result: {result}");
            }

            return result;
        }

        private static int GoRight(Grid grid, BeamTracer beamTracer)
        {
            var result = 0;

            for (int i = 0; i < grid.NumberOfRows; i++)
            {
                var temp = beamTracer.NumberOfPointsAffectedByBeam(i, 0, [Direction.Right]);
                result = Math.Max(result, temp);
                Console.WriteLine($"Row {i} column 0: {temp}  Result: {result}");
            }

            return result;
        }
    }
}
