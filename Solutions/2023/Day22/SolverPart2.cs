namespace Day22
{
    internal class SolverPart2
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            List<Brick> bricks = [];

            foreach (var line in lines)
            {
                var brick = new Brick(line);
                bricks.Add(brick);
            }

            var result = 0L;

            Parallel.For(1, bricks.Count + 1, brickIndex =>
            {
                var tower = new Tower(bricks);
                tower.Stabalize();
                var falling = tower.Remove(brickIndex);

                Interlocked.Add(ref result, falling);
                Console.WriteLine($"Removed brick {brickIndex} with result {result}");
            });

            return result;
        }
    }
}
