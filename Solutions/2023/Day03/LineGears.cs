
using System.Text.RegularExpressions;

namespace Day03
{
    internal class LineGears
    {
        private string _line;
        private int _lineNumber;

        public LineGears(string line, int lineNumber)
        {
            _line = line;
            _lineNumber = lineNumber;
        }

        internal IEnumerable<Gear> GetGears()
        {
            var result = new List<Gear>();
            var gears = Regex.EnumerateMatches(_line, @"\*");

            foreach (var gearMatch in gears)
            {
                var gear = new Gear(gearMatch.Index, _lineNumber);
                result.Add(gear);
            }

            return result;
        }
    }
}
