namespace Day14
{
    internal class GridBuilder
    {
        private List<string> _lines = [];

        public GridBuilder Add(string gridLine)
        {
            _lines.Add(gridLine);
            return this;
        }

        public Grid Build()
        {
            char[][] grid = new char[_lines.Count][];

            for (int i = 0; i < _lines.Count; i++)
            {
                grid[i] = _lines[i].ToCharArray();
            }

            return new Grid(grid);
        }
    }
}
