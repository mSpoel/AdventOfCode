
namespace Day13
{
    internal class PatternBuilder
    {
        private List<string> _lines = [];

        public PatternBuilder Add(string patternLine)
        {
            _lines.Add(patternLine);
            return this;
        }

        public Pattern Build()
        {
            char[][] pattern = new char[_lines.Count][];

            for (int i = 0; i < _lines.Count; i++)
            {
                pattern[i] = _lines[i].ToCharArray();
            }

            return new Pattern(pattern);
        }

        public int NumberOfRows => _lines.Count;

        public int NumberOfColumns => _lines[0].Length;
    }
}
