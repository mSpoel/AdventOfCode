namespace Day05
{
    internal class SolverPart1
    {
        internal static string GetSolution(string inputPath, int numberOfStacks)
        {
            InputReader.ReadInputFile(inputPath, numberOfStacks, out Dictionary<int, Stack<char>> stacks, out List<Step> steps);

            foreach (var step in steps)
            {
                var fromStack = stacks[step.From];
                var toStack = stacks[step.To];

                for (int i = 0; i < step.Move; i++)
                {
                    var character = fromStack.Pop();
                    toStack.Push(character);
                }
            }

            string result = string.Empty;
            for (int i = 0; i < numberOfStacks; i++)
            {
                var stack = stacks[i + 1];
                result += stack.Peek();
            }

            return result;
        }
    }
}
