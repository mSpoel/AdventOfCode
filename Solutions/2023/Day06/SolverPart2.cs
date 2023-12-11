using System.Text.RegularExpressions;

namespace Day06
{
    internal class SolverPart2
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var time = long.Parse(string.Join("", Regex.Matches(lines[0], @"\d+")));
            var distance = long.Parse(string.Join("", Regex.Matches(lines[1], @"\d+")));

            return RaceCalculator.CalculateWinningOptions(new Race(time, distance));
        }
    }
}
