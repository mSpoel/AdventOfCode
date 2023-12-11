namespace Day10
{
    internal class GridItem
    {
        public GridItem(char symbol, List<Direction> directions)
        {
            Symbol = symbol;
            Directions = directions;
        }

        public char Symbol { get; }

        public List<Direction> Directions { get; }
    }
}
