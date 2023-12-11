
namespace Day10
{
    internal class Grid
    {
        private Dictionary<Coordinate, GridItem> _grid;

        public int NumberOfColumns { get; internal set; }
        public int NumberOfRows { get; internal set; }

        public Grid(Dictionary<Coordinate, GridItem> grid)
        {
            _grid = grid;
            NumberOfColumns = _grid.Keys.Max(x => x.Column) + 1;
            NumberOfRows = _grid.Keys.Max(x => x.Row) + 1;
        }

        public Coordinate GetStartingPoint()
        {
            var startingPoint = _grid.Where(x => x.Value.Symbol == 'S').First();
            return startingPoint.Key;
        }

        public GridItem GetGridItem(Coordinate coordinate)
        {
            return _grid[coordinate];
        }

        public bool IsExpanded(int row, int column)
        {
            foreach (var keys in _grid.Keys)
            {
                if (keys.Row == row && keys.Column == column)
                {
                    return keys.IsExpanded;
                }
            }

            return false;
        }

        internal IEnumerable<Coordinate> GetNeighbours(Coordinate currentCoordinate)
        {
            var neighbours = new List<Coordinate>();

            int row = currentCoordinate.Row;
            int column = currentCoordinate.Column;

            var north = new Coordinate(row - 1, column);
            var south = new Coordinate(row + 1, column);
            var west = new Coordinate(row, column - 1);
            var east = new Coordinate(row, column + 1);

            if (_grid.ContainsKey(north) && IsConnected(currentCoordinate, north, Direction.North))
            {
                neighbours.Add(north);
            }

            if (_grid.ContainsKey(south) && IsConnected(currentCoordinate, south, Direction.South))
            {
                neighbours.Add(south);
            }

            if (_grid.ContainsKey(west) && IsConnected(currentCoordinate, west, Direction.West))
            {
                neighbours.Add(west);
            }

            if (_grid.ContainsKey(east) && IsConnected(currentCoordinate, east, Direction.East))
            {
                neighbours.Add(east);
            }

            return neighbours;
        }

        private bool IsConnected(Coordinate current, Coordinate next, Direction direction)
        {
            if (!_grid[current].Symbol.Equals('S') &&
                !_grid[current].Directions.Contains(direction))
            {
                return false;
            }

            var item = _grid[next];

            if (_grid[next].Symbol.Equals('S') &&
                _grid[current].Directions.Contains(direction))
            {
                return true;
            }

            Direction oppositeDirection;
            if (direction == Direction.East)
            {
                oppositeDirection = Direction.West;
            }
            else if (direction == Direction.West)
            {
                oppositeDirection = Direction.East;
            }
            else if (direction == Direction.North)
            {
                oppositeDirection = Direction.South;
            }
            else
            {
                oppositeDirection = Direction.North;
            }

            return item.Directions.Contains(oppositeDirection);
        }

        internal void Expand()
        {
            var gridItems = new GridItems();
            var expandedGrid = new Dictionary<Coordinate, GridItem>();

            for (int row = 0; row < NumberOfRows; row++)
            {
                int newColumnFirst = 0;
                int newColumnExpanded = 1;
                for (int column = 0; column < NumberOfColumns; column++)
                {
                    if (column == NumberOfColumns - 1)
                    {
                        expandedGrid.Add(new Coordinate(row, newColumnFirst), _grid[new Coordinate(row, column)]);
                        continue;
                    }

                    var currentCoordinate = new Coordinate(row, column);
                    var nextCoordinate = new Coordinate(row, column + 1);
                    var item = _grid[currentCoordinate];

                    expandedGrid.Add(new Coordinate(row, newColumnFirst), item);

                    if (IsConnected(currentCoordinate, nextCoordinate, Direction.East))
                    {
                        var gridItem = gridItems.GetItem('-');
                        expandedGrid.Add(new Coordinate(row, newColumnExpanded, true), gridItem);
                    }
                    else
                    {
                        var gridItem = gridItems.GetItem('.');
                        expandedGrid.Add(new Coordinate(row, newColumnExpanded, true), gridItem);
                    }

                    newColumnFirst += 2;
                    newColumnExpanded += 2;
                }
            }

            _grid = expandedGrid;
            NumberOfColumns = _grid.Keys.Max(x => x.Column) + 1;
            NumberOfRows = _grid.Keys.Max(x => x.Row) + 1;

            var expandedGrid2 = new Dictionary<Coordinate, GridItem>();

            for (int column = 0; column < NumberOfColumns; column++)
            {
                int newRowFirst = 0;
                int newRowExpanded = 1;
                for (int row = 0; row < NumberOfRows; row++)
                {
                    if (row == NumberOfRows - 1)
                    {
                        expandedGrid2.Add(new Coordinate(newRowFirst, column), _grid[new Coordinate(row, column)]);
                        continue;
                    }

                    var currentCoordinate = new Coordinate(row, column);
                    var nextCoordinate = new Coordinate(row + 1, column);
                    var item = _grid[currentCoordinate];

                    expandedGrid2.Add(new Coordinate(newRowFirst, column, IsExpanded(row, column)), item);

                    if (IsConnected(currentCoordinate, nextCoordinate, Direction.South))
                    {
                        var gridItem = gridItems.GetItem('|');
                        expandedGrid2.Add(new Coordinate(newRowExpanded, column, true), gridItem);
                    }
                    else
                    {
                        var gridItem = gridItems.GetItem('.');
                        expandedGrid2.Add(new Coordinate(newRowExpanded, column, true), gridItem);
                    }

                    newRowFirst += 2;
                    newRowExpanded += 2;
                }
            }

            _grid = expandedGrid2;
            NumberOfColumns = _grid.Keys.Max(x => x.Column) + 1;
            NumberOfRows = _grid.Keys.Max(x => x.Row) + 1;
        }
    }
}