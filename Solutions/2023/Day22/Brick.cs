
namespace Day22
{
    internal class Brick
    {
        private readonly List<(int x, int y, int z)> _cubes = [];

        public Brick(string line)
        {
            var parts = line.Split('~');
            var first = parts[0];
            var second = parts[1];
            var firstX = int.Parse(first.Split(',')[0]);
            var firstY = int.Parse(first.Split(',')[1]);
            var firstZ = int.Parse(first.Split(',')[2]);
            var secondX = int.Parse(second.Split(',')[0]);
            var secondY = int.Parse(second.Split(',')[1]);
            var secondZ = int.Parse(second.Split(',')[2]);

            for (int x = firstX; x <= secondX; x++)
            {
                for (int y = firstY; y <= secondY; y++)
                {
                    for (int z = firstZ; z <= secondZ; z++)
                    {
                        _cubes.Add((x, y, z));
                    }
                }
            }
        }

        public Brick(IEnumerable<(int X, int Y, int Z)> cubes)
        {
            _cubes.AddRange(cubes);
        }

        internal IEnumerable<(int X, int Y, int Z)> GetCubes()
        {
            return _cubes;
        }
    }
}