namespace Day10
{
    internal class Coordinate
    {
        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
            IsExpanded = false;
        }

        public Coordinate(int row, int column, bool isExpanded)
        {
            Row = row;
            Column = column;
            IsExpanded = isExpanded;
        }

        public int Row { get; }

        public int Column { get; }

        public bool IsExpanded { get; }

        public override bool Equals(object obj)
        {
            var other = obj as Coordinate;
            return other != null && other.Row == Row && other.Column == Column;
        }

        public override int GetHashCode()
        {
            return Row.GetHashCode() ^ Column.GetHashCode();
        }
    }
}
