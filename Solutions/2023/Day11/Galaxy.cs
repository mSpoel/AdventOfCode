




namespace Day11
{
    internal class Galaxy
    {
        private Dictionary<Coordinate, char> _galaxy;

        public Galaxy(Dictionary<Coordinate, char> galaxy)
        {
            _galaxy = galaxy;
        }

        public int NumberOfColumns => _galaxy.Keys.Max(c => c.Column) + 1;

        public int NumberOfRows => _galaxy.Keys.Max(c => c.Row) + 1;

        public void Expand()
        {
            Dictionary<Coordinate, char> expanded = new Dictionary<Coordinate, char>();

            //First expand the rows
            int newRowIndex = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                var row = _galaxy.Keys.Where(c => c.Row == i).ToList();
                if (!ContainsGalaxy(row))
                {
                    foreach (var coordinate in row)
                    {
                        expanded.Add(new Coordinate(newRowIndex, coordinate.Column), '.');
                        expanded.Add(new Coordinate(newRowIndex + 1, coordinate.Column), '.');
                    }
                    newRowIndex++;
                }
                else
                {
                    foreach (var coordinate in row)
                    {
                        expanded.Add(new Coordinate(newRowIndex, coordinate.Column), _galaxy[coordinate]);
                    }
                }
                newRowIndex++;
            }

            _galaxy = expanded;
            expanded = new Dictionary<Coordinate, char>();

            //Then expand the columns
            int newColumnIndex = 0;
            for (int i = 0; i < NumberOfColumns; i++)
            {
                var column = _galaxy.Keys.Where(c => c.Column == i).ToList();
                if (!ContainsGalaxy(column))
                {
                    foreach (var coordinate in column)
                    {
                        expanded.Add(new Coordinate(coordinate.Row, newColumnIndex), '.');
                        expanded.Add(new Coordinate(coordinate.Row, newColumnIndex + 1), '.');
                    }
                    newColumnIndex++;
                }
                else
                {
                    foreach (var coordinate in column)
                    {
                        expanded.Add(new Coordinate(coordinate.Row, newColumnIndex), _galaxy[coordinate]);
                    }
                }
                newColumnIndex++;
            }

            _galaxy = expanded;
        }

        public void WriteToConsole()
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            for (int row = 0; row < NumberOfRows - 1; row++)
            {
                for (int column = 0; column < NumberOfColumns - 1; column++)
                {
                    Console.Write(GetItem(row, column));
                }
                Console.Write("\n");
            }
        }

        public char GetItem(int row, int column)
        {
            return _galaxy[new Coordinate(row, column)];
        }

        public List<Coordinate> GetGalaxies()
        {
            var galaxies = new List<Coordinate>();
            foreach (var coordinate in _galaxy.Keys)
            {
                if (IsGalaxy(coordinate))
                {
                    galaxies.Add(coordinate);
                }
            }

            return galaxies;
        }

        public List<int> RowsWithoutGalaxy()
        {
            var rowsWithoutGalaxy = new List<int>();
            for (int row = 0; row < NumberOfRows; row++)
            {
                var coordinates = _galaxy.Keys.Where(c => c.Row == row).ToList();
                if (!ContainsGalaxy(coordinates))
                {
                    rowsWithoutGalaxy.Add(row);
                }
            }

            return rowsWithoutGalaxy;
        }

        public List<int> ColumnsWithoutGalaxy()
        {
            var columnsWithoutGalaxy = new List<int>();
            for (int column = 0; column < NumberOfColumns; column++)
            {
                var coordinates = _galaxy.Keys.Where(c => c.Column == column).ToList();
                if (!ContainsGalaxy(coordinates))
                {
                    columnsWithoutGalaxy.Add(column);
                }
            }

            return columnsWithoutGalaxy;
        }

        private bool ContainsGalaxy(List<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (IsGalaxy(coordinate))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsGalaxy(Coordinate coordinate)
        {
            if (_galaxy[coordinate] == '#')
            {
                return true;
            }

            return false;
        }
    }
}
