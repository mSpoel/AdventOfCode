namespace Day10
{
    internal class GridBuilder
    {
        private string[] _lines;
        private GridItems _gridItems;

        public GridBuilder(string[] lines)
        {
            _lines = lines;
            _gridItems = new GridItems();
        }

        public Grid Build()
        {
            var grid = new Dictionary<Coordinate, GridItem>();

            for (int row = 0; row < _lines.Length; row++)
            {
                var line = _lines[row];

                for (int column = 0; column < line.Length; column++)
                {
                    var character = line[column];
                    var coordinate = new Coordinate(row, column);
                    var gridItem = _gridItems.GetItem(character);
                    grid.Add(coordinate, gridItem);
                }
            }

            return new Grid(grid);
        }
    }
}
