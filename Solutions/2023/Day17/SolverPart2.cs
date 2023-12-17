using Utilities;

namespace Day17
{
    internal class SolverPart2
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            int[][] grid = new int[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                grid[i] = lines[i].ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
            }

            var shortestPath = new ShortestPath(grid);

            result = shortestPath.GetShortestPath((0, 0), (grid.Length - 1, grid[0].Length - 1), [Direction.Right, Direction.Down], 4, 10);

            return result;
        }
    }
}
