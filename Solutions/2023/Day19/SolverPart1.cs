namespace Day19
{
    internal class SolverPart1
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            int result = 0;

            var ruleEngine = new RuleEngine();

            bool isRules = true;

            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    isRules = false;
                    continue;
                }

                if (isRules)
                {
                    ruleEngine.AddRule(new MachineRule(line));
                }
                else
                {
                    result += ruleEngine.Process(new Parts(line));
                }
            }

            return result;
        }
    }
}
