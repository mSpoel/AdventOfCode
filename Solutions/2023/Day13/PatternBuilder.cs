
namespace Day13
{
    internal class PatternBuilder
    {
        private List<string> _lines = [];
        private int _rowToReplace = -1;
        private int _columnToRepace = -1;
        private List<int> _rowsToIgnore = [];
        private List<int> _columnsToIgnore = [];

        public PatternBuilder Add(string patternLine)
        {
            _lines.Add(patternLine);
            return this;
        }

        public PatternBuilder Replace(int row, int column)
        {
            _rowToReplace = row;
            _columnToRepace = column;

            return this;
        }

        public Pattern Build()
        {
            char[][] pattern = new char[_lines.Count][];

            for (int i = 0; i < _lines.Count; i++)
            {
                var array = _lines[i].ToCharArray();

                if (_rowToReplace == i)
                {
                    var c = array[_columnToRepace];
                    if (c == '.')
                    {
                        array[_columnToRepace] = '#';
                    }
                    else
                    {
                        array[_columnToRepace] = '.';
                    }
                }

                pattern[i] = array;
            }

            return new Pattern(pattern, _rowsToIgnore, _columnsToIgnore);
        }

        internal void Ignore(List<int> rowsToIgnore, List<int> columnsToIgnore)
        {
            _rowsToIgnore = rowsToIgnore;
            _columnsToIgnore = columnsToIgnore;

            if (_rowsToIgnore.Count() > 1 || _columnsToIgnore.Count() > 1)
            {
                int x = 0;
            }
        }

        public int NumberOfRows => _lines.Count;

        public int NumberOfColumns => _lines[0].Length;
    }
}
