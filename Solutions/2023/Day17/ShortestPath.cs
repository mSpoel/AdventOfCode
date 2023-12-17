using Utilities;

namespace Day17
{
    internal class ShortestPath
    {
        private readonly Dictionary<Coordinate2D, int> _map = [];

        public ShortestPath(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    _map.Add((i, j), grid[i][j]);
                }
            }
        }

        public int GetShortestPath((int row, int column) start, (int row, int column) end, List<Direction> startDirections, int minRunLength, int maxRunLength)
        {
            Dictionary<(Coordinate2D location, Direction direction, int runLength), int> distances = [];
            Dictionary<(Coordinate2D location, Direction direction, int runLength), (Coordinate2D loc, Direction direction, int runLength)> previousState = [];

            PriorityQueue<(Coordinate2D location, Direction direction, int runLength), int> queue = new();

            foreach (var startDirection in startDirections)
            {
                distances[((start.row, start.column), startDirection, 0)] = 0;
                queue.Enqueue(((start.row, start.column), startDirection, 0), 0);

            }

            while (queue.TryDequeue(out var current, out int cost))
            {
                if (current.location == end)
                {
                    return cost;
                }

                foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                {
                    if (direction == current.direction.Reverse())
                    {
                        continue; // Don't go back the way we came
                    }

                    if (direction != current.direction && current.runLength < minRunLength)
                    {
                        continue; // We are not allowed to turn before we have gone minRunLength steps straight
                    }

                    if (direction == current.direction && current.runLength == maxRunLength)
                    {
                        continue; // We are not allowed to go straight for more than maxRunLength steps
                    }

                    var nextLocation = current.location.Move(direction);

                    if (!_map.ContainsKey(nextLocation))
                    {
                        continue; // We are not allowed to go outside the grid
                    }

                    var nextState = (nextLocation, direction, direction == current.direction ? current.runLength + 1 : 1);
                    int nextDistance = distances[current] + _map[nextLocation];

                    if (nextDistance < distances.GetValueOrDefault(nextState, int.MaxValue))
                    {
                        distances[nextState] = nextDistance;
                        previousState[nextState] = current;
                        queue.Enqueue(nextState, nextDistance);
                    }
                }
            }

            return 0;
        }
    }
}
