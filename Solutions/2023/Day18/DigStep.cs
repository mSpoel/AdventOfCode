using Utilities;

namespace Day18
{
    internal class DigStep
    {
        public DigStep(string line)
        {
            var parts = line.Split(' ');

            Direction = parts[0] switch
            {
                "U" => Direction.Up,
                "R" => Direction.Right,
                "D" => Direction.Down,
                "L" => Direction.Left,
                _ => throw new Exception($"Unknown direction: {parts[0]}")
            };

            Steps = int.Parse(parts[1]);

            Color = parts[2];
        }

        public DigStep(Direction direction, int steps)
        {
            Direction = direction;
            Steps = steps;
            Color = string.Empty;
        }

        public Direction Direction { get; }

        public int Steps { get; }

        public string Color { get; }

        internal DigStep SwapColorsAndInstructionParameters()
        {
            var hexaLength = Color.Substring(2, 5);
            var direction = Color.Substring(7, 1);

            int lenght = int.Parse(hexaLength, System.Globalization.NumberStyles.HexNumber);

            switch (direction)
            {
                case "0":
                    return new DigStep(Direction.Right, lenght);
                case "1":
                    return new DigStep(Direction.Down, lenght);
                case "2":
                    return new DigStep(Direction.Left, lenght);
                case "3":
                    return new DigStep(Direction.Up, lenght);
                default:
                    throw new Exception($"Unknown direction: {direction}");
            }
        }
    }
}