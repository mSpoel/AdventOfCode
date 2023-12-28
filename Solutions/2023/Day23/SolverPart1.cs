using Utilities;

namespace Day23
{
    internal class SolverPart1
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

            var start = (0, 1);
            var end = (grid.NumberOfRows - 1, grid.NumberOfColumns - 2);

            var queue = new Queue<((int row, int column) coordinate, List<(int row, int column)> path)>();

            List<List<(int row, int column)>> paths = [];

            queue.Enqueue((start, []));

            while (queue.Count > 0)
            {
                var (coordinate, path) = queue.Dequeue();

                if (coordinate == end)
                {
                    if (!paths.Contains(path))
                    {
                        paths.Add(path); ;
                    }

                    continue;
                }

                var currentChar = grid.Get(coordinate);
                var currentPath = path;

                switch (currentChar)
                {
                    case '<':
                        ProcessNext(Direction.Left, grid, queue, coordinate, currentPath);
                        continue;
                    case '>':
                        ProcessNext(Direction.Right, grid, queue, coordinate, currentPath);
                        continue;
                    case '^':
                        ProcessNext(Direction.Up, grid, queue, coordinate, currentPath);
                        continue;
                    case 'v':
                        ProcessNext(Direction.Down, grid, queue, coordinate, currentPath);
                        continue;
                }

                foreach (var direction in Enum.GetValues<Direction>())
                {
                    var next = grid.GetNextPoint(coordinate, direction);

                    if (!grid.IsInGrid(next) || grid.Get(next) == '#')
                    {
                        continue;
                    }

                    if (currentPath.Contains(next))
                    {
                        continue;
                    }

                    var updatedPath = new List<(int row, int column)>(currentPath);
                    updatedPath.Add(next);
                    queue.Enqueue((next, updatedPath));
                }
            }

            //grid.WriteToConsole();

            return paths.Max(p => p.Count);
        }

        private static void ProcessNext(Direction direction, Grid grid, Queue<((int row, int column) coordinate, List<(int row, int column)> path)> queue, (int row, int column) coordinate, List<(int row, int column)> currentPath)
        {
            var next = grid.GetNextPoint(coordinate, direction);

            if (!grid.IsInGrid(next))
            {
                return;
            }

            if (currentPath.Contains(next))
            {
                return;
            }

            currentPath.Add(next);
            queue.Enqueue((grid.GetNextPoint(coordinate, direction), currentPath));
        }
    }
}
