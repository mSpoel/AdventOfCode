using Utilities;

namespace Day23
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
            var start = (0, 1);
            var end = (grid.NumberOfRows - 1, grid.NumberOfColumns - 2);

            var stack = new Stack<((int row, int column) coordinate, HashSet<(int row, int column)> path)>();
            HashSet<HashSet<(int row, int column)>> paths = new HashSet<HashSet<(int row, int column)>>();
            stack.Push((start, new HashSet<(int row, int column)>()));

            Dictionary<(int row, int column), int> memo = [];
            var result = 0;
            var stackSize = 0;

            while (stack.Count > 0)
            {
                var (coordinate, path) = stack.Pop();

                if (coordinate == end)
                {
                    if (!paths.Contains(path))
                    {
                        result = Math.Max(result, path.Count);
                        paths.Add(path);
                        Console.WriteLine($"Path found with length: {path.Count}. Result so far {result}");
                    }
                    continue;
                }
                foreach (var direction in Enum.GetValues<Direction>())
                {
                    var next = grid.GetNextPoint(coordinate, direction);
                    if (!grid.IsInGrid(next) || grid.Get(next) == '#' || path.Contains(next))
                    {
                        continue;
                    }
                    var updatedPath = new HashSet<(int row, int column)>(path);
                    updatedPath.Add(next);
                    stack.Push((next, updatedPath));
                }

                if (stack.Count != stackSize)
                {
                    stackSize = stack.Count;
                    Console.WriteLine($"Stack size: {stack.Count}");
                }
            }

            return paths.Max(p => p.Count);
        }
    }
}
