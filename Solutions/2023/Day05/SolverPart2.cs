using Day05;

internal class SolverPart2
{
    internal long GetSolution(string inputPath)
    {
        string[] lines = File.ReadAllLines(inputPath);

        var seedRanges = Seeds.GetRanges(lines[0]);

        var locationCalculator = new LocationCalculator(lines);

        return locationCalculator.GetMinLocationRangeBased(seedRanges);
    }
}