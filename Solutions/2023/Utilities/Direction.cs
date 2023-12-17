namespace Utilities
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class DirectionExtensions
    {
        public static Direction Reverse(this Direction direction) => direction switch
        {
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}
