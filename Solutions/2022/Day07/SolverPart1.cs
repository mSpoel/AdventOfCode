namespace Day07
{
    internal class SolverPart1
    {
        internal static int GetSolution(string inputPath)
        {
            string[] lines = System.IO.File.ReadAllLines(inputPath);
            Directory workingDirectory = InputReader.Process(lines);

            return GetTotalSize(workingDirectory);
        }

        private static int GetTotalSize(Directory directory)
        {
            int maxTotalSize = 100000;
            int result = 0;

            var totalSize = directory.GetTotalSize();
            if (totalSize <= maxTotalSize)
            {
                result += totalSize;
            }

            foreach (var subDir in directory.Directories)
            {
                result += GetTotalSize(subDir);
            }

            return result;
        }
    }
}
