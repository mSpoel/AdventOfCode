namespace Day08
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var directions = lines[0];

            var map = new Map(lines.Skip(2));

            var routeCalculator = new RouteCalculator(map, directions);

            return routeCalculator.GetNumberOfSteps("AAA", new List<string> { "ZZZ" });
        }
    }
}
