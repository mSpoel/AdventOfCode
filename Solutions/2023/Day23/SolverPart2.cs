using Utilities;

namespace Day23
{
    internal class SolverPart2
    {
        internal long GetSolution(string inputPath)
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

            var intersections = GetIntersections(grid);
            intersections.Add(start);
            intersections.Add(end);

            Dictionary<(int row, int column), Dictionary<(int row, int column), int>> distances = [];
            foreach (var intersection in intersections)
            {
                var distance = BreadthFirstSearch(grid, intersection, intersections);
                distances.Add(intersection, distance);
                Console.Write($"{intersection}: ");
                foreach (var d in distance)
                {
                    Console.Write($" {d.Key}: {d.Value}");
                }
                Console.WriteLine();

            }

            return DepthFirstSearch(distances, start, end);
        }

        private static long DepthFirstSearch(Dictionary<(int row, int column), Dictionary<(int row, int column), int>> graph, (int row, int column) start, (int row, int column) end)
        {
            long maxDistance = 0;
            var stack = new Stack<((int row, int column) coordinate, int distance, HashSet<(int row, int column)> visited)>();
            var initVisit = new HashSet<(int row, int column)>
            {
                start
            };
            stack.Push((start, 0, initVisit));

            while (stack.Count > 0)
            {
                var (coordinate, distance, visited) = stack.Pop();

                //Console.WriteLine($"Coordinate: {coordinate} \t Distance: {distance} \t Visited: {visited.Count}");

                if (coordinate == end)
                {
                    maxDistance = Math.Max(maxDistance, distance);
                    Console.WriteLine($"Found path with distance: {distance}. Max distance {maxDistance}");
                    continue;
                }

                foreach (var neighbor in graph[coordinate])
                {
                    if (visited.Contains(neighbor.Key))
                    {
                        continue;
                    }

                    var newDistance = distance + neighbor.Value;
                    var newVisited = new HashSet<(int row, int column)>(visited)
                    {
                        neighbor.Key
                    };
                    stack.Push((neighbor.Key, newDistance, newVisited));

                    //Console.Write($"Neighbor: {neighbor.Key} \t Distance: {neighbor.Value} \t newDistance {newDistance}");
                    //foreach (var v in newVisited)
                    //{
                    //    Console.Write($" {v}");
                    //}
                    //Console.WriteLine();
                }
            }

            return maxDistance;
        }

        private static Dictionary<(int row, int column), int> BreadthFirstSearch(Grid grid, (int row, int column) start, List<(int row, int column)> intersections)
        {
            var queue = new Queue<((int row, int column), int distance)>();
            var visited = new HashSet<(int row, int column)>();
            var distances = new Dictionary<(int row, int column), int>();

            queue.Enqueue((start, 0));

            while (queue.Count > 0)
            {
                var (coordinate, distance) = queue.Dequeue();

                if (intersections.Contains(coordinate) && coordinate != start)
                {
                    distances.Add(coordinate, distance);
                    continue;
                }

                var nextDistance = distance + 1;
                foreach (var direction in Enum.GetValues<Direction>())
                {
                    var next = grid.GetNextPoint(coordinate, direction);

                    if (!grid.IsInGrid(next) || grid.Get(next) == '#' || visited.Contains(next))
                    {
                        continue;
                    }

                    visited.Add(next);
                    queue.Enqueue((next, nextDistance));
                }
            }

            return distances;
        }

        private static List<(int, int)> GetIntersections(Grid grid)
        {
            // Find all tiles that have more than 2 neighbors
            var intersections = new List<(int, int)>();

            for (int row = 0; row < grid.NumberOfRows - 1; row++)
            {
                for (int col = 0; col < grid.NumberOfColumns - 1; col++)
                {
                    if (grid.Get((row, col)) == '#')
                    {
                        continue;
                    }

                    int neighbors = 0;

                    foreach (var direction in Enum.GetValues<Direction>())
                    {
                        var next = grid.GetNextPoint((row, col), direction);

                        if (!grid.IsInGrid(next) || grid.Get(next) == '#')
                        {
                            continue;
                        }

                        neighbors++;
                    }

                    if (neighbors > 2)
                    {
                        intersections.Add((row, col));
                    }
                }
            }

            return intersections;
        }
    }
}
