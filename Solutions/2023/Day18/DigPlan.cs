using Utilities;

namespace Day18
{
    internal class DigPlan
    {
        private List<DigStep> _digSteps = [];

        public DigPlan(string[] lines)
        {
            foreach (var line in lines)
            {
                var digStep = new DigStep(line);
                _digSteps.Add(digStep);
            }
        }

        public void SwapColorsAndInstructionParameters()
        {
            var temp = new List<DigStep>();

            foreach (var digStep in _digSteps)
            {
                DigStep swapped = digStep.SwapColorsAndInstructionParameters();
                temp.Add(swapped);
            }

            _digSteps = temp;
        }

        public List<Coordinate2D> GetEdges()
        {
            var result = new List<Coordinate2D>();

            var currentLocation = new Coordinate2D(0, 0);
            result.Add(currentLocation);

            foreach (var digStep in _digSteps)
            {
                Console.WriteLine($"Digging current location {currentLocation} {digStep.Steps} steps {digStep.Direction}");

                switch (digStep.Direction)
                {
                    case Direction.Up:
                        currentLocation = new Coordinate2D(currentLocation.Row - digStep.Steps, currentLocation.Column);
                        break;
                    case Direction.Down:
                        currentLocation = new Coordinate2D(currentLocation.Row + digStep.Steps, currentLocation.Column);
                        break;
                    case Direction.Right:
                        currentLocation = new Coordinate2D(currentLocation.Row, currentLocation.Column + digStep.Steps);
                        break;
                    case Direction.Left:
                        currentLocation = new Coordinate2D(currentLocation.Row, currentLocation.Column - digStep.Steps);
                        break;
                    default:
                        throw new Exception($"Unknown direction: {digStep.Direction}");
                }

                result.Add(currentLocation);
            }

            return result;
        }

        public char[][] Dig()
        {
            // Day 10 had flood fill
            // Determine the size of the grid
            var numberOfRows = _digSteps.Where(x => x.Direction == Direction.Right).Select(x => x.Steps).Sum();
            var numberOfColumns = _digSteps.Where(x => x.Direction == Direction.Down).Select(x => x.Steps).Sum();

            var result = new char[numberOfRows][];

            // Initialize the grid
            for (int i = 0; i < numberOfRows; i++)
            {
                result[i] = new char[numberOfColumns];
                for (int j = 0; j < numberOfColumns; j++)
                {
                    result[i][j] = '.';
                }
            }

            // Dig the grid
            var currentLocation = new Coordinate2D(0, 0);
            foreach (var digStep in _digSteps)
            {
                switch (digStep.Direction)
                {
                    case Direction.Up:
                        for (var i = 1; i <= digStep.Steps; i++)
                        {
                            result[currentLocation.Row - i][currentLocation.Column] = '#';
                        }
                        currentLocation = new Coordinate2D(currentLocation.Row - digStep.Steps, currentLocation.Column);
                        break;
                    case Direction.Down:
                        for (var i = 1; i <= digStep.Steps; i++)
                        {
                            result[currentLocation.Row + i][currentLocation.Column] = '#';
                        }
                        currentLocation = new Coordinate2D(currentLocation.Row + digStep.Steps, currentLocation.Column);
                        break;
                    case Direction.Right:
                        for (var i = 1; i <= digStep.Steps; i++)
                        {
                            result[currentLocation.Row][currentLocation.Column + i] = '#';
                        }
                        currentLocation = new Coordinate2D(currentLocation.Row, currentLocation.Column + digStep.Steps);
                        break;
                    case Direction.Left:
                        for (var i = 1; i <= digStep.Steps; i++)
                        {
                            result[currentLocation.Row][currentLocation.Column - i] = '#';
                        }
                        currentLocation = new Coordinate2D(currentLocation.Row, currentLocation.Column - digStep.Steps);
                        break;
                    default:
                        throw new Exception($"Unknown direction: {digStep.Direction}");
                }

            }

            result.WriteToConsole();

            return result;
        }

        internal int GetCircumferenceLength()
        {
            return _digSteps.Select(x => x.Steps).Sum();
        }
    }
}