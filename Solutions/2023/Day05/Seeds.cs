using System.Text.RegularExpressions;

namespace Day05
{
    internal static class Seeds
    {
        public static IEnumerable<long> Get(string line)
        {
            return Regex.Matches(line, @"\d+")
                .Select(m => long.Parse(m.Value))
                .ToList();
        }

        public static List<(long From, long To)> GetRanges(string line)
        {
            var seeds = Get(line);

            var ranges = new List<(long From, long To)>();

            for (int i = 0; i < seeds.Count(); i += 2)
            {
                ranges.Add((seeds.ElementAt(i), seeds.ElementAt(i) + seeds.ElementAt(i + 1)));
            }

            return ranges;
        }
    }
}
