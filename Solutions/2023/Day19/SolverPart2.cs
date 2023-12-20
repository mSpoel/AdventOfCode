namespace Day19
{
    internal class SolverPart2
    {
        internal ulong GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var ruleEngine = new RuleEngine();

            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    break;
                }

                ruleEngine.AddRule(new MachineRule(line));
            }

            return ruleEngine.GetCombinations();
        }
    }
}
