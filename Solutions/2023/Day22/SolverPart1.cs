namespace Day22
{
    internal class SolverPart1
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

            var tower = new Tower(bricks);
            tower.Stabalize();

            return tower.GetNumberOfRemovableBricks();
        }
    }
}
