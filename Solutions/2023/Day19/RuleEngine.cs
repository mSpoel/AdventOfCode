namespace Day19
{
    internal class RuleEngine
    {
        private readonly Dictionary<string, MachineRule> _rules = [];

        internal void AddRule(MachineRule rule)
        {
            _rules.Add(rule.Name, rule);
        }

        internal MachineRule GetRule(string ruleName)
        {
            return _rules[ruleName];
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

        public ulong GetCombinations()
        {
            Range rangeX = new(1, 4000);
            Range rangeM = new(1, 4000);
            Range rangeA = new(1, 4000);
            Range rangeS = new(1, 4000);

            List<(Range X, Range M, Range A, Range S)> validCombinations = [];
            List<(Range X, Range M, Range A, Range S)> rejectedCombinations = [];

            var queue = new Queue<(Range rangeX, Range rangeM, Range rangeA, Range rangeS, string nextRule, int step)>();
            queue.Enqueue((rangeX, rangeM, rangeA, rangeS, "in", 0));

            while (queue.Count > 0)
            {
                var (X, M, A, S, nextRule, step) = queue.Dequeue();

                if (nextRule == "A")
                {
                    //This is a valid combination
                    validCombinations.Add((X, M, A, S));
                    //Console.WriteLine($"Valid combination x:{X},m:{M},a:{A},s:{S}");
                    continue;
                }

                if (nextRule == "R")
                {
                    rejectedCombinations.Add((X, M, A, S));
                    continue;
                }

                var (expression, rule) = _rules[nextRule].GetRule(step);

                Console.WriteLine($"{nextRule} [{GetCombinationsAsString(X, M, A, S)} ] {rule}");
                //Console.WriteLine($"{nextRule} {step} -> x:{X},m:{M},a:{A},s:{S}\t{expression} -> {rule} 0");

                if (!IsEvalutation(expression))
                {
                    queue.Enqueue((X, M, A, S, expression, 0));
                    //Console.WriteLine($"Enqueue x:{X},m:{M},a:{A},s:{S} -> {expression} 0");
                    continue;
                }

                //update ranges
                if (expression.StartsWith('x'))
                {
                    foreach (var passedX in Ranges.GetPassRanges(expression, X))
                    {
                        queue.Enqueue((passedX, M, A, S, rule, 0));
                        //Console.WriteLine($"Enqueue x:{newRangeX},m:{M},a:{A},s:{S} -> {rule} 0");
                    }

                    foreach (var failedX in Ranges.GetFailRanges(expression, X))
                    {
                        queue.Enqueue((failedX, M, A, S, nextRule, ++step));
                        //Console.WriteLine($"Enqueue x:{newRangeX},m:{M},a:{A},s:{S} -> {nextRule} {step}");
                    }

                }
                else if (expression.StartsWith('m'))
                {
                    foreach (var passedM in Ranges.GetPassRanges(expression, M))
                    {
                        queue.Enqueue((X, passedM, A, S, rule, 0));
                        //Console.WriteLine($"Enqueue x:{X},m:{newRangeM},a:{A},s:{S} -> {rule} 0");
                    }

                    foreach (var failedM in Ranges.GetFailRanges(expression, M))
                    {
                        queue.Enqueue((X, failedM, A, S, nextRule, ++step));
                        //Console.WriteLine($"Enqueue x:{X},m:{newRangeM},a:{A},s:{S} -> {nextRule} {step}");
                    }
                }
                else if (expression.StartsWith('a'))
                {
                    foreach (var passedA in Ranges.GetPassRanges(expression, A))
                    {
                        queue.Enqueue((X, M, passedA, S, rule, 0));
                        //Console.WriteLine($"Enqueue x:{X},m:{M},a:{newRangeA},s:{S} -> {rule} 0");
                    }

                    foreach (var failedA in Ranges.GetFailRanges(expression, A))
                    {
                        queue.Enqueue((X, M, failedA, S, nextRule, ++step));
                        //Console.WriteLine($"Enqueue x:{X},m:{M},a:{newRangA},s:{S} -> {nextRule} {step}");
                    }
                }
                else if (expression.StartsWith('s'))
                {
                    foreach (var passedS in Ranges.GetPassRanges(expression, S))
                    {
                        queue.Enqueue((X, M, A, passedS, rule, 0));
                        //Console.WriteLine($"Enqueue x:{X},m:{M},a:{A},s:{newRangeS} -> {rule} 0");
                    }

                    foreach (var failedS in Ranges.GetFailRanges(expression, S))
                    {
                        queue.Enqueue((X, M, A, failedS, nextRule, ++step));
                        //Console.WriteLine($"Enqueue x:{X},m:{M},a:{A},s:{newRangeS} -> {nextRule} {step}");
                    }
                }
            }

            Console.WriteLine($"Valid combinations: {validCombinations.Count}");
            ulong result = 0;
            foreach (var (X, M, A, S) in validCombinations)
            {
                Console.WriteLine($"Valid combination x:{X},m:{M},a:{A},s:{S}");

                ulong x = (ulong)(X.End.Value - X.Start.Value + 1);
                ulong m = (ulong)(M.End.Value - M.Start.Value + 1);
                ulong a = (ulong)(A.End.Value - A.Start.Value + 1);
                ulong s = (ulong)(S.End.Value - S.Start.Value + 1);
                result += x * m * a * s;
            }

            return result;
        }

        private string GetCombinationsAsString(Range X, Range M, Range A, Range S)
        {
            ulong x = (ulong)(X.End.Value - X.Start.Value + 1);
            ulong m = (ulong)(M.End.Value - M.Start.Value + 1);
            ulong a = (ulong)(A.End.Value - A.Start.Value + 1);
            ulong s = (ulong)(S.End.Value - S.Start.Value + 1);
            var result = x * m * a * s;

            return result.ToString().Replace(".", string.Empty);
        }

        private static bool IsEvalutation(string expression)
        {
            return expression.Contains('>') ||
                expression.Contains('<') ||
                expression.Contains('=');
        }
    }
}
