namespace Utilities
{
    public class Grid
    {
        private char[][] _grid;

        public Grid(char[][] grid)
        {
            _grid = grid;
        }

        public int NumberOfRows => _grid.Length;

        public int NumberOfColumns => _grid[0].Length;

        public Grid Clone()
        {
            var result = new char[_grid.Length][];
            for (int i = 0; i < _grid.Length; i++)
            {
                result[i] = new char[_grid[0].Length];
                for (int j = 0; j < _grid[0].Length; j++)
                {
                    result[i][j] = _grid[i][j];
                }
            }

            return new Grid(result);
        }

        public char Get(int row, int column)
        {
            return _grid[row][column];
        }

        public int GetCount(char c)
        {
            int result = 0;

            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = 0; j < _grid[0].Length; j++)
                {
                    if (_grid[i][j] == c)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public (int row, int column) GetNextPoint(int row, int column, Direction direction)
        {
            return direction switch
            {
                Direction.Up => (row - 1, column),
                Direction.Down => (row + 1, column),
                Direction.Left => (row, column - 1),
                Direction.Right => (row, column + 1),
                _ => throw new Exception("Unknown direction"),
            };
        }

        public bool IsInGrid(int row, int column)
        {
            return row >= 0 && row < NumberOfRows && column >= 0 && column < NumberOfColumns;
        }

        public void Set(int nextRow, int nextColumn, char c)
        {
            _grid[nextRow][nextColumn] = c;
        }

        public void WriteToConsole()
        {
            WriteToConsole([]);
        }

        public void WriteToConsole(List<(int highLightRow, int highLightColumn)> highLights)
        {
            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = 0; j < _grid[0].Length; j++)
                {
                    if (highLights.Any(hl => hl.highLightRow == i && hl.highLightColumn == j))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(_grid[i][j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
