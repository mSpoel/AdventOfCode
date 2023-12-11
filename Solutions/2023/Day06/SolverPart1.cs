using System.Text.RegularExpressions;

namespace Day06
{
    internal class SolverPart1
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var times = Regex.Matches(lines[0], @"\d+")
                .Select(m => int.Parse(m.Value))
                .ToList();

            var distances = Regex.Matches(lines[1], @"\d+")
                .Select(m => int.Parse(m.Value))
                .ToList();

            List<Race> races = new List<Race>();

            for (int i = 0; i < times.Count; i++)
            {
                races.Add(new Race(times[i], distances[i]));
            }

            int result = 1;
            foreach (var race in races)
            {
                result *= RaceCalculator.CalculateWinningOptions(race);
            }

            return result;
        }
    }
}
