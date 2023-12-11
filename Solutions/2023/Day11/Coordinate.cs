namespace Day11
{
    internal class Coordinate
    {
        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }

        public int Column { get; }

        public override bool Equals(object obj)
        {
            var other = obj as Coordinate;
            return other != null && other.Row == Row && other.Column == Column;
        }

        public override int GetHashCode()
        {
            return Row.GetHashCode() ^ Column.GetHashCode();
        }

        public override string ToString()
        {
            return $"(Row {Row}, Column {Column})";
        }
    }
}