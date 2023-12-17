
namespace Utilities
{
    public class Coordinate2D
    {
        public Coordinate2D(long row, long column)
        {
            Row = row;
            Column = column;
        }

        public Coordinate2D((long row, long column) coordinate)
        {
            Row = coordinate.row;
            Column = coordinate.column;
        }

        public long Row { get; }

        public long Column { get; }

        public static bool operator ==(Coordinate2D a, Coordinate2D b) => (a.Row == b.Row && a.Column == b.Column);

        public static bool operator !=(Coordinate2D a, Coordinate2D b) => (a.Row != b.Row || a.Column != b.Column);

        public static implicit operator Coordinate2D((int x, int y) a) => new(a.x, a.y);

        public static implicit operator (long x, long y)(Coordinate2D a) => (a.Row, a.Column);

        public Coordinate2D Move(Direction direction)
        {
            return (direction) switch
            {
                Direction.Up => new Coordinate2D(Row - 1, Column),
                Direction.Down => new Coordinate2D(Row + 1, Column),
                Direction.Left => new Coordinate2D(Row, Column - 1),
                Direction.Right => new Coordinate2D(Row, Column + 1),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Coordinate2D)) return false;
            return this == (Coordinate2D)obj;
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
