using Utilities;

namespace Day16
{
    internal class BeamTracer
    {
        private readonly Grid _grid;

        public BeamTracer(Grid grid)
        {
            _grid = grid;
        }

        public int NumberOfPointsAffectedByBeam(int startRow, int startColumn, Direction direction)
        {
            var nextDirections = GetNextDirections(_grid.Get(startRow, startColumn), direction);

            _grid.WriteToConsole(new List<(int, int)> { (startRow, startColumn) });
            Console.WriteLine();

            var affectedGrid = _grid.Clone();

            List<Beam> beams = new();
            List<Beam> processedBeams = new();

            foreach (var nextDirection in nextDirections)
            {
                beams.Add(new Beam(startRow, startColumn, nextDirection));
                affectedGrid.Set(startRow, startColumn, '#');
            }

            while (beams.Any())
            {
                List<Beam> newBeams = [];

                foreach (var beam in beams)
                {
                    if (processedBeams.Contains(beam))
                    {
                        continue;
                    }

                    processedBeams.Add(beam);
                    var (nextRow, nextColumn) = _grid.GetNextPoint(beam.CurrentRow, beam.CurrentColumn, beam.Direction);
                    if (!_grid.IsInGrid(nextRow, nextColumn))
                    {
                        //Beam moved out of grid, so it is not affecting any points
                        continue;
                    }

                    List<Direction> directions = GetNextDirections(_grid.Get(nextRow, nextColumn), beam.Direction);

                    foreach (var nextDirection in directions)
                    {
                        if (!newBeams.Contains(new Beam(nextRow, nextColumn, nextDirection)))
                        {
                            newBeams.Add(new Beam(nextRow, nextColumn, nextDirection));
                            affectedGrid.Set(nextRow, nextColumn, '#');
                        }
                    }
                }

                beams.Clear();
                beams.AddRange(newBeams);

                //Console.Clear();

                //affectedGrid.WriteToConsole(beams.Select(b => (b.CurrentRow, b.CurrentColumn)).ToList());
                //Console.WriteLine($"beams: {beams.Count}");
                //foreach (var beam in beams)
                //{
                //    Console.WriteLine($"({beam.CurrentRow}, {beam.CurrentColumn}) {beam.Direction}");
                //}
                //Console.WriteLine("");
            }

            //affectedGrid.WriteToConsole();

            return affectedGrid.GetCount('#');
        }

        private static List<Direction> GetNextDirections(char operation, Direction direction)
        {
            var result = new List<Direction>();

            switch (operation)
            {
                case '.':
                    result.Add(direction);
                    break;
                case '\\':
                    switch (direction)
                    {
                        case Direction.Up:
                            result.Add(Direction.Left);
                            break;
                        case Direction.Down:
                            result.Add(Direction.Right);
                            break;
                        case Direction.Left:
                            result.Add(Direction.Up);
                            break;
                        case Direction.Right:
                            result.Add(Direction.Down);
                            break;
                    }
                    break;
                case '/':
                    switch (direction)
                    {
                        case Direction.Up:
                            result.Add(Direction.Right);
                            break;
                        case Direction.Down:
                            result.Add(Direction.Left);
                            break;
                        case Direction.Left:
                            result.Add(Direction.Down);
                            break;
                        case Direction.Right:
                            result.Add(Direction.Up);
                            break;
                    }
                    break;
                case '|':
                    switch (direction)
                    {
                        case Direction.Up:
                            result.Add(Direction.Up);
                            break;
                        case Direction.Down:
                            result.Add(Direction.Down);
                            break;
                        case Direction.Left:
                            result.Add(Direction.Up);
                            result.Add(Direction.Down);
                            break;
                        case Direction.Right:
                            result.Add(Direction.Up);
                            result.Add(Direction.Down);
                            break;
                    }
                    break;
                case '-':
                    switch (direction)
                    {
                        case Direction.Up:
                            result.Add(Direction.Left);
                            result.Add(Direction.Right);
                            break;
                        case Direction.Down:
                            result.Add(Direction.Left);
                            result.Add(Direction.Right);
                            break;
                        case Direction.Left:
                            result.Add(Direction.Left);
                            break;
                        case Direction.Right:
                            result.Add(Direction.Right);
                            break;
                    }
                    break;
                default:
                    throw new Exception("Unknown character");
            }

            return result;
        }
    }
}
