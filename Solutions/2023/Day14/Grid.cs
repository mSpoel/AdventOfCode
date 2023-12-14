

namespace Day14
{
    internal class Grid
    {
        private char[][] _grid;

        public Grid(char[][] grid)
        {
            _grid = grid;
        }

        public int GetWeigth(int numberOfCycles)
        {
            // Each cycle spins the grid. First north, then west, then south, then east.

            for (int i = 0; i < numberOfCycles; i++)
            {
                _grid = GetNextGrid(_grid);
            }

            return 0;
        }

        private char[][] GetNextGrid(char[][] grid)
        {
            Console.WriteLine("start");
            WriteToConsole(grid);

            grid = MoveNorth(grid);
            Console.WriteLine("north");
            WriteToConsole(grid);

            grid = MoveWest(grid);
            Console.WriteLine("west");
            WriteToConsole(grid);

            grid = MoveSouth(grid);
            Console.WriteLine("south");
            WriteToConsole(grid);

            grid = MoveEast(grid);
            Console.WriteLine("east");
            WriteToConsole(grid);

            return grid;
        }

        private char[][] MoveEast(char[][] grid)
        {
            throw new NotImplementedException();
        }

        private char[][] MoveSouth(char[][] grid)
        {
            throw new NotImplementedException();
        }

        private char[][] MoveWest(char[][] grid)
        {
            throw new NotImplementedException();
        }

        private char[][] MoveNorth(char[][] grid)
        {
            var transposed = Transpose(grid);

            var newGrid = new char[grid.Length][];

            int rowIndex = 0;
            foreach (var row in transposed)
            {
                var newRow = new char[grid.Length];
                string rowAsStringrow = string.Join("", row);
                var sections = rowAsStringrow.Split('#');

                int index = 0;
                foreach (var section in sections)
                {
                    //Something wrong with placing the #
                    if (section.Length == 0)
                    {
                        newRow[index] = '#';
                        index++;
                    }
                    else if (section.Contains('O'))
                    {
                        var numberOfO = section.Count(c => c == 'O');
                        while (numberOfO > 0)
                        {
                            newRow[index] = 'O';
                            index++;
                            numberOfO--;
                        }

                        var numberOfDots = section.Count(c => c == '.');
                        while (numberOfDots > 0)
                        {
                            newRow[index] = '.';
                            index++;
                            numberOfDots--;
                        }
                    }
                    else
                    {
                        foreach (var c in section)
                        {
                            newRow[index] = c;
                            index++;
                        }
                    }
                }

                newGrid[rowIndex] = newRow;
                rowIndex++;
            }

            return Transpose(newGrid);
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
