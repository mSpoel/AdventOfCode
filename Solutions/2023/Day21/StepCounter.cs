using Utilities;

namespace Day21
{
    internal class StepCounter
    {
        private readonly Grid _grid;

        internal StepCounter(Grid grid)
        {
            _grid = grid;
        }

        internal int GetReachablePlots(int numberOfSteps)
        {
            var startingPoint = _grid.GetNodesWith('S')[0];

            List<(int row, int column)> startingPoints = [startingPoint];

            for (int i = 0; i < numberOfSteps; i++)
            {
                List<(int row, int column)> workingSet = [];
                foreach (var point in startingPoints)
                {
                    var neighbours = _grid.GetNeighbours(point.row, point.column);

                    foreach (var neighbour in neighbours)
                    {
                        if (_grid.Get(neighbour.row, neighbour.column) == '#')
                        {
                            continue;
                        }

                        if (!workingSet.Contains(neighbour))
                        {
                            workingSet.Add(neighbour);
                        }
                    }
                }

                startingPoints = workingSet;
            }

            return startingPoints.Count();
        }
    }
}
