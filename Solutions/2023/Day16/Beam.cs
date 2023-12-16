using Utilities;

namespace Day16
{
    internal struct Beam
    {
        public Beam(int currentRow, int currentColumn, Direction direction)
        {
            CurrentRow = currentRow;
            CurrentColumn = currentColumn;
            Direction = direction;
        }

        public int CurrentRow { get; }
        public int CurrentColumn { get; }
        public Direction Direction { get; }
    }
}
