

namespace Day14
{
    internal class Grid
    {
        private char[][] _grid;

        private int NumberOfRows(char[][] grid) => grid.Length;

        private int NumberOfColumns(char[][] grid) => grid[0].Length;


        public Grid(char[][] grid)
        {
            _grid = grid;
        }

        public int GetWeigth(int numberOfCycles)
        {
            var grid = Iterate(numberOfCycles);

            return GetWeight(grid);
        }

        private char[][] Iterate(int numberOfCycles)
        {
            // Each cycle spins the grid. First north, then west, then south, then east.
            var history = new List<string>();

            while (numberOfCycles > 0)
            {
                _grid = Cycle(_grid);
                numberOfCycles--;

                var mapAsString = string.Join("\n", _grid.Select(line => new string(line)));
                var index = history.IndexOf(mapAsString);
                if (index < 0)
                {
                    history.Add(mapAsString);
                }
                else
                {
                    var loopLength = history.Count - history.IndexOf(mapAsString);
                    var remainingCycles = numberOfCycles % loopLength;

                    var result = history[index + remainingCycles];
                    return result.Split('\n').Select(line => line.ToCharArray()).ToArray();
                }
            }

            return _grid;
        }

        private char[][] Cycle(char[][] grid)
        {
            //Console.WriteLine("Start cycle");
            //WriteToConsole(grid);

            for (int i = 0; i < 4; i++)
            {
                grid = Rotate(TiltToNorth(grid));
            }

            //Console.WriteLine("End cycle");
            //WriteToConsole(grid);

            return grid;
        }

        private char[][] TiltToNorth(char[][] grid)
        {
            for (int column = 0; column < NumberOfColumns(grid); column++)
            {
                int rowNext0 = 0;
                for (int row = 0; row < NumberOfRows(grid); row++)
                {
                    if (grid[row][column] == '#')
                    {
                        rowNext0 = row + 1;
                    }
                    else if (grid[row][column] == 'O')
                    {
                        grid[row][column] = '.';
                        grid[rowNext0][column] = 'O';
                        rowNext0++;
                    }
                }
            }

            return grid;
        }

        private char[][] Rotate(char[][] grid)
        {
            //rotate the grid 90 degrees clockwise
            var result = new char[NumberOfRows(grid)][];

            for (int row = 0; row < NumberOfColumns(grid); row++)
            {
                result[row] = new char[NumberOfColumns(grid)];
                for (int column = 0; column < NumberOfRows(grid); column++)
                {
                    result[row][column] = grid[NumberOfRows(grid) - column - 1][row];
                }
            }

            return result;
        }

        public int GetWeightToNorth()
        {
            var transposedGrid = Transpose(_grid);

            int result = 0;

            foreach (var row in transposedGrid)
            {
                string rowAsStringrow = string.Join("", row);

                Console.WriteLine(rowAsStringrow);

                var sections = rowAsStringrow.Split('#');

                int weight = _grid.Length;
                foreach (var section in sections)
                {
                    Console.WriteLine(section);
                    if (section.Contains("O"))
                    {
                        int startWeight = weight;
                        foreach (var c in section)
                        {
                            if (c == 'O')
                            {
                                Console.Write($"O weight {weight}");
                                result += weight;
                                weight--;
                                Console.Write($" - O result {result} \n");
                            }
                        }
                        weight = startWeight - section.Length - 1;
                    }
                    else
                    {
                        weight = weight - section.Length - 1;
                    }
                }
            }

            return result;
        }

        private int GetWeight(char[][] array)
        {
            int result = 0;

            int weight = NumberOfRows(array);

            foreach (var row in array)
            {
                var numberOfO = row.Count(c => c == 'O');
                result += numberOfO * weight;
                weight--;
            }

            return result;
        }

        private static char[][] Transpose(char[][] array)
        {
            var result = new char[array[0].Length][];

            for (int i = 0; i < array[0].Length; i++)
            {
                result[i] = new char[array.Length];
                for (int j = 0; j < array.Length; j++)
                {
                    result[i][j] = array[j][i];
                }
            }

            return result;
        }

        internal void WriteToConsole(char[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    Console.Write(grid[i][j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
