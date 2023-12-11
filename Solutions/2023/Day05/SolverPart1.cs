using Day05;

internal class SolverPart1
{
    internal long GetSolution(string inputPath)
    {
        string[] lines = File.ReadAllLines(inputPath);

        IEnumerable<long> seeds = Seeds.Get(lines[0]);

        var locationCalculator = new LocationCalculator(lines);

        var locations = new List<long>();

        foreach (var seed in seeds)
        {
            var location = locationCalculator.GetLocation(seed);
            locations.Add(location);
        }

        return locations.Min();
    }
}
