namespace Day06
{
    internal class SolverPart2
    {
        internal static int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            foreach (var line in lines)
            {
                result += BufferProcessor.GetFirstMarkerPosition(line, 14);
            }

            return result;
        }
    }
}
