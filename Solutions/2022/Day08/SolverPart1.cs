namespace Day08
{
    internal class SolverPart1
    {
        internal static int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            var grid = InputReader.Read(lines);
            List<(int row, int column)> visited = [];

            for (int row = 0; row < grid.Length; row++)
            {
                int highest = -1;
                for (int column = 0; column < grid[row].Length; column++)
                {
                    if (grid[row][column] > highest)
                    {
                        highest = grid[row][column];

                        if (visited.Contains((row, column)))
                        {
                            continue;
                        }

                        visited.Add((row, column));
                        result++;
                    }
                }
            }

            for (int column = 0; column < grid[0].Length; column++)
            {
                int highest = -1;
                for (int row = 0; row < grid.Length; row++)
                {
                    if (grid[row][column] > highest)
                    {
                        highest = grid[row][column];

                        if (visited.Contains((row, column)))
                        {
                            continue;
                        }

                        visited.Add((row, column));
                        result++;
                    }
                }
            }

            for (int row = grid.Length - 1; row >= 0; row--)
            {
                int highest = -1;
                for (int column = grid[row].Length - 1; column >= 0; column--)
                {
                    if (grid[row][column] > highest)
                    {
                        highest = grid[row][column];

                        if (visited.Contains((row, column)))
                        {
                            continue;
                        }

                        visited.Add((row, column));
                        result++;
                    }
                }
            }

            for (int column = grid[0].Length - 1; column >= 0; column--)
            {
                int highest = -1;
                for (int row = grid.Length - 1; row >= 0; row--)
                {
                    if (grid[row][column] > highest)
                    {
                        highest = grid[row][column];

                        if (visited.Contains((row, column)))
                        {
                            continue;
                        }

                        visited.Add((row, column));
                        result++;
                    }
                }
            }

            return result;
        }


    }
}
