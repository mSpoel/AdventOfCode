using Utilities;

namespace Day23
{
    internal class SolverPart2BFS
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

            var queue = new Queue<((int row, int column) coordinate, HashSet<(int row, int column)> path)>();

            HashSet<HashSet<(int row, int column)>> paths = [];

            queue.Enqueue((start, []));

            while (queue.Count > 0)
            {
                var (coordinate, path) = queue.Dequeue();

                if (coordinate == end)
                {
                    if (!paths.Contains(path))
                    {
                        paths.Add(path);
                        Console.WriteLine($"Path found with length: {path.Count}");
                    }

                    continue;
                }

                var currentPath = path;

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

                    var updatedPath = new HashSet<(int row, int column)>(currentPath);
                    updatedPath.Add(next);
                    queue.Enqueue((next, updatedPath));
                }
            }

            return paths.Max(p => p.Count);
        }
    }
}
