namespace Utilities
{
    public static class ArrayExtensions
    {
        public static void WriteToConsole(this char[][] grid)
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
