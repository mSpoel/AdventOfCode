using Utilities;

namespace Day21
{
    internal class SolverPart2
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var builder = new GridBuilder();

            foreach (var line in lines)
            {
                builder.Add(line);
            }

            var grid = builder.Build();

            // Credits go to
            // https://github.com/villuna/aoc23/wiki/A-Geometric-solution-to-advent-of-code-2023,-day-21

            var startingPoint = grid.GetNodesWith('S')[0];
            Dictionary<(int row, int column), int> paths = Dijkstra(grid, startingPoint);

            long nrEvenPlotsInSingleMap = paths.Count(e => e.Value % 2 == 0);
            long nrOddPlotsInSingleMap = paths.Count(e => e.Value % 2 == 1);

            long nrEvenPlotsInCorner = paths.Count(e => e.Value > 65 && e.Value % 2 == 0);
            long nrOddPlotsInCorner = paths.Count(e => e.Value > 65 && e.Value % 2 == 1);

            long nrHorizontalSquares = (26501365 - 65) / 131;
            long totalNrOddPlots = (nrHorizontalSquares + 1) * (nrHorizontalSquares + 1) * nrOddPlotsInSingleMap;
            long totalNrEvenPlots = nrHorizontalSquares * nrHorizontalSquares * nrEvenPlotsInSingleMap;
            long totalNrForOddCorners = (nrHorizontalSquares + 1) * nrOddPlotsInCorner;
            long totalNrForEvenCorners = nrHorizontalSquares * nrEvenPlotsInCorner;

            return totalNrOddPlots + totalNrEvenPlots - totalNrForOddCorners + totalNrForEvenCorners;
        }

        private Dictionary<(int row, int column), int> Dijkstra(Grid grid, (int row, int column) startingPoint)
        {
            var result = new Dictionary<(int row, int column), int>();

            var queue = new Queue<(int row, int column)>();

            queue.Enqueue(startingPoint);

            result.Add(startingPoint, 0);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                var neighbours = grid.GetNeighbours(current.row, current.column);

                foreach (var neighbour in neighbours)
                {
                    if (grid.Get(neighbour.row, neighbour.column) == '#')
                    {
                        continue;
                    }

                    if (!result.ContainsKey(neighbour))
                    {
                        result.Add(neighbour, result[current] + 1);
                        queue.Enqueue(neighbour);
                    }
                }
            }
            return result;
        }
    }
}
