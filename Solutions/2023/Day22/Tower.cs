

namespace Day22
{
    internal class Tower
    {
        private readonly int[,,] _cubes;
        private readonly Dictionary<int, Brick> _bricks = [];

        public Tower(List<Brick> bricks)
        {
            var maxX = bricks.Max(b => b.GetCubes().Max(c => c.X));
            var maxY = bricks.Max(b => b.GetCubes().Max(c => c.Y));
            var maxZ = bricks.Max(b => b.GetCubes().Max(c => c.Z));

            _cubes = new int[maxX + 1, maxY + 1, maxZ + 1];

            int brickIndex = 1;
            foreach (var brick in bricks)
            {
                foreach (var (X, Y, Z) in brick.GetCubes())
                {
                    _cubes[X, Y, Z] = brickIndex;
                }

                _bricks.Add(brickIndex++, brick);
            }
        }

        public long GetDisintegrationResult()
        {
            var result = 0;

            foreach (var brickIndex in _bricks.Keys)
            {
                var brick = _bricks[brickIndex];
            }
            return result;
        }

        public long Stabalize()
        {
            List<int> fallingBricks = [];

            bool falling = true;
            while (falling)
            {
                falling = false;
                foreach (var brickIndex in _bricks.Keys)
                {
                    var minZ = _bricks[brickIndex].GetCubes().Min(c => c.Z);

                    if (minZ == 1)
                    {
                        continue;
                    }

                    var bricksBelow = GetBrickIndexesBelow(brickIndex);

                    if (bricksBelow.Count > 0)
                    {
                        continue;
                    }

                    foreach (var (X, Y, Z) in _bricks[brickIndex].GetCubes())
                    {
                        _cubes[X, Y, Z] = 0;
                        _cubes[X, Y, Z - 1] = brickIndex;

                    }

                    _bricks[brickIndex] = new Brick(_bricks[brickIndex].GetCubes().Select(c => (c.X, c.Y, c.Z - 1)));

                    if (!fallingBricks.Contains(brickIndex))
                    {
                        fallingBricks.Add(brickIndex);
                    }
                    falling = true;
                }

                //Print();
            }

            return fallingBricks.Count;
        }

        internal List<int> GetBrickIndexesBelow(int brickIndex)
        {
            var brickIndexesBelow = new List<int>();

            var brick = _bricks[brickIndex];

            foreach (var (X, Y, Z) in brick.GetCubes())
            {
                if (Z == 0)
                {
                    continue;
                }

                (int X, int Y, int Z) cubeBelow = (X, Y, Z - 1);
                var brickIndexBelow = _cubes[cubeBelow.X, cubeBelow.Y, cubeBelow.Z];

                if (brickIndexBelow == 0 || brickIndexBelow == brickIndex)
                {
                    continue;
                }

                if (brickIndexesBelow.Contains(brickIndexBelow))
                {
                    continue;
                }

                brickIndexesBelow.Add(brickIndexBelow);
            }

            return brickIndexesBelow;
        }

        internal List<int> GetBrickIndexesAbove(int brickIndex)
        {
            var brickIndexesAbove = new List<int>();

            var brick = _bricks[brickIndex];

            foreach (var (X, Y, Z) in brick.GetCubes())
            {
                if (Z == _cubes.GetLength(2) - 1)
                {
                    continue;
                }

                (int X, int Y, int Z) cubeAbove = (X, Y, Z + 1);
                var brickIndexAbove = _cubes[cubeAbove.X, cubeAbove.Y, cubeAbove.Z];

                if (brickIndexAbove == 0 || brickIndexAbove == brickIndex)
                {
                    continue;
                }

                if (brickIndexesAbove.Contains(brickIndexAbove))
                {
                    continue;
                }

                brickIndexesAbove.Add(brickIndexAbove);
            }

            return brickIndexesAbove;
        }

        internal long GetNumberOfRemovableBricks()
        {
            List<int> removableBricks = [];

            foreach (var brickIndex in _bricks.Keys)
            {
                var brickIndexesAbove = GetBrickIndexesAbove(brickIndex);

                if (brickIndexesAbove.Count == 0)
                {
                    // No bricks above, so this brick is removable
                    removableBricks.Add(brickIndex);
                    continue;
                }

                bool isOnlyBrickBelowForAll = true;
                foreach (var brickIndexAbove in brickIndexesAbove)
                {
                    var brickIndexesBelow = GetBrickIndexesBelow(brickIndexAbove);

                    if (brickIndexesBelow.Count == 1)
                    {
                        isOnlyBrickBelowForAll = false;
                        break;
                    }
                }

                if (isOnlyBrickBelowForAll)
                {
                    removableBricks.Add(brickIndex);
                }
            }

            return removableBricks.Count;
        }

        internal void Print()
        {
            var maxZ = _cubes.GetLength(2) - 1;
            var maxY = _cubes.GetLength(1) - 1;
            var maxX = _cubes.GetLength(0) - 1;

            Console.WriteLine("y");
            for (var y = 0; y <= maxY; y++)
            {
                Console.Write(y);
            }
            Console.WriteLine();

            for (var z = maxZ; z >= 0; z--)
            {
                for (var x = 0; x <= maxX; x++)
                {
                    var maxIndexX = 0;
                    for (var y = 0; y <= maxY; y++)
                    {
                        maxIndexX = Math.Max(maxIndexX, _cubes[x, y, z]);
                    }
                    Console.Write($"{maxIndexX}");

                }
                Console.Write($" {z}");
                Console.WriteLine();
            }

            Console.WriteLine("x");
            for (var x = 0; x <= maxX; x++)
            {
                Console.Write(x);
            }
            Console.WriteLine();

            for (var z = maxZ; z >= 0; z--)
            {
                for (var y = 0; y <= maxY; y++)
                {
                    var maxIndexY = 0;
                    for (var x = 0; x <= maxX; x++)
                    {
                        maxIndexY = Math.Max(maxIndexY, _cubes[x, y, z]);
                    }
                    Console.Write($"{maxIndexY}");

                }
                Console.Write($" {z}");
                Console.WriteLine();
            }
        }

        internal long Remove(int brickIndex)
        {
            var brick = _bricks[brickIndex];

            foreach (var (X, Y, Z) in brick.GetCubes())
            {
                _cubes[X, Y, Z] = 0;
            }
            _bricks.Remove(brickIndex);

            return Stabalize();
        }
    }
}