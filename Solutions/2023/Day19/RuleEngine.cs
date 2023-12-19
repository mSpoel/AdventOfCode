namespace Day19
{
    internal class RuleEngine
    {
        private readonly Dictionary<string, MachineRule> _rules = [];

        internal void AddRule(MachineRule rule)
        {
            _rules.Add(rule.Name, rule);
        }

        internal int Process(Parts parts, string startingRule = "in")
        {
            Console.Write($"x:{parts.X},m:{parts.M},a:{parts.A},s:{parts.S}\t");
            var ruleName = startingRule;
            while (_rules.TryGetValue(ruleName, out var rule))
            {
                Console.Write($"{ruleName} -> ");
                ruleName = rule.Evaluate(parts);

                if (ruleName == "R")
                {
                    Console.Write("R\n");
                    return 0;
                }

                if (ruleName == "A")
                {
                    var result = parts.X + parts.A + parts.M + parts.S;
                    Console.Write($"A: add {result}\n");
                    return result;
                }
            }

            return 0;
        }
    }
}
