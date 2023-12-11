namespace Day10
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var grid = new GridBuilder(lines).Build();
            var costs = InitCosts(lines.Length, lines[0].Length);

            var startingPoint = grid.GetStartingPoint();

            var coordinatesToVisit = new Queue<Coordinate>();
            coordinatesToVisit.Enqueue(startingPoint);

            var coordinatesVisited = new HashSet<Coordinate>
            {
                startingPoint
            };

            while (coordinatesToVisit.Count > 0)
            {
                var currentCoordinate = coordinatesToVisit.Dequeue();
                var currentGridItem = grid.GetGridItem(currentCoordinate);

                var neighbours = grid.GetNeighbours(currentCoordinate);

                foreach (var neighbour in neighbours)
                {
                    if (coordinatesVisited.Contains(neighbour))
                    {
                        continue;
                    }
                    costs[neighbour] = costs[currentCoordinate] + 1;
                    Console.WriteLine($"From {currentCoordinate.Row},{currentCoordinate.Column} visiting {neighbour.Row},{neighbour.Column}. Costs {costs[neighbour]}");
                    coordinatesToVisit.Enqueue(neighbour);
                }

                coordinatesVisited.Add(currentCoordinate);
            }

            return costs.Max(x => x.Value);
        }

        private static Dictionary<Coordinate, int> InitCosts(int numberOfRows, int numberOfColumns)
        {
            var costs = new Dictionary<Coordinate, int>();
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    costs.Add(new Coordinate(row, column), 0);
                }
            }

            return costs;
        }
    }
}
