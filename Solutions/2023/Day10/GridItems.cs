namespace Day10
{
    internal class GridItems
    {
        /*
         * | is a vertical pipe connecting north and south.
         * - is a horizontal pipe connecting east and west.
         * L is a 90-degree bend connecting north and east.
         * J is a 90-degree bend connecting north and west.
         * 7 is a 90-degree bend connecting south and west.
         * F is a 90-degree bend connecting south and east.
         * . is ground; there is no pipe in this tile.
         * S is the starting position of the animal.
         */
        private readonly Dictionary<char, GridItem> _items;

        public GridItems()
        {
            _items = new Dictionary<char, GridItem>();
            _items.Add('|', new GridItem('|', new List<Direction> { Direction.North, Direction.South }));
            _items.Add('-', new GridItem('-', new List<Direction> { Direction.East, Direction.West }));
            _items.Add('L', new GridItem('L', new List<Direction> { Direction.North, Direction.East }));
            _items.Add('J', new GridItem('J', new List<Direction> { Direction.North, Direction.West }));
            _items.Add('7', new GridItem('7', new List<Direction> { Direction.South, Direction.West }));
            _items.Add('F', new GridItem('F', new List<Direction> { Direction.South, Direction.East }));
            _items.Add('.', new GridItem('.', new List<Direction>()));
            _items.Add('S', new GridItem('S', new List<Direction>()));
        }

        public GridItem GetItem(char symbol)
        {
            return _items[symbol];
        }
    }
}
