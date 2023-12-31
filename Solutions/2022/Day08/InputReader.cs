namespace Day08
{
    internal class InputReader
    {
        internal static int[][] Read(string[] lines)
        {
            int[][] grid = new int[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                for (int j = 0; j < line.Length; j++)
                {
                    if (grid[i] == null)
                    {
                        grid[i] = new int[line.Length];
                    }

                    grid[i][j] = int.Parse(line[j].ToString());
                }
            }

            return grid;
        }
    }
}
