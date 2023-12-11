namespace Day11
{
    internal class GalaxyBuilder
    {
        private string[] _lines;

        public GalaxyBuilder(string[] lines)
        {
            _lines = lines;
        }

        public Galaxy Build()
        {
            var galaxy = new Dictionary<Coordinate, char>();

            for (int i = 0; i < _lines.Length; i++)
            {
                var line = _lines[i];

                for (int j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    var coordinate = new Coordinate(i, j);
                    galaxy.Add(coordinate, character);
                }
            }

            return new Galaxy(galaxy);
        }
    }
}
