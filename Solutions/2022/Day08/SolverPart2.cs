namespace Day08
{
    internal class SolverPart2
    {
        internal static int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            var grid = InputReader.Read(lines);

            for (int row = 0; row < grid.Length; row++)
            {
                for (int column = 0; column < grid[row].Length; column++)
                {
                    int scenicScore = GetScenicScore(grid, row, column);

                    result = Math.Max(result, scenicScore);
                }
            }

            return result;
        }

        private static int GetScenicScore(int[][] grid, int row, int column)
        {
            int currentHeight = grid[row][column];

            // Right side
            int right = 0;
            for (int i = column + 1; i < grid[row].Length; i++)
            {
                if (grid[row][i] >= currentHeight)
                {
                    right++;
                    break;
                }

                right++;
            }

            // Left side
            int left = 0;
            for (int i = column - 1; i >= 0; i--)
            {
                if (grid[row][i] >= currentHeight)
                {
                    left++;
                    break;
                }

                left++;
            }

            // Top side
            int top = 0;
            for (int i = row - 1; i >= 0; i--)
            {
                if (grid[i][column] >= currentHeight)
                {
                    top++;
                    break;
                }

                top++;
            }

            // Bottom side
            int bottom = 0;
            for (int i = row + 1; i < grid.Length; i++)
            {
                if (grid[i][column] >= currentHeight)
                {
                    bottom++;
                    break;
                }

                bottom++;
            }


            return right * left * top * bottom;
        }
    }
}
