namespace Day07
{
    internal class SolverPart2
    {
        internal static int GetSolution(string inputPath)
        {
            string[] lines = System.IO.File.ReadAllLines(inputPath);

            Directory workingDirectory = InputReader.Process(lines);

            int totalDiskSize = 70000000;
            int updateSize = 30000000;
            int usedSize = workingDirectory.GetTotalSize();

            return GetMinSizeToRemove(workingDirectory, usedSize + updateSize - totalDiskSize);

        }

        private static int GetMinSizeToRemove(Directory directory, int sizeRequired)
        {
            if (directory.GetTotalSize() < sizeRequired)
            {
                return int.MaxValue;
            }

            int result = directory.GetTotalSize();

            foreach (var subDir in directory.Directories)
            {
                result = Math.Min(result, GetMinSizeToRemove(subDir, sizeRequired));
            }

            return result;
        }
    }
}
