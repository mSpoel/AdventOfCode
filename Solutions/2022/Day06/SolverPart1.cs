namespace Day06
{
    internal class SolverPart1
    {
        internal static int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            foreach (var line in lines)
            {
                result += BufferProcessor.GetFirstMarkerPosition(line, 4);
            }

            return result;
        }
    }
}
