namespace Day05
{
    internal static class InputReader
    {
        internal static void ReadInputFile(string inputPath, int numberOfStacks, out Dictionary<int, Stack<char>> stacks, out List<Step> steps)
        {
            string[] lines = File.ReadAllLines(inputPath);

            bool isPlan = false;
            int[] positions = new int[numberOfStacks];
            for (int i = 0; i < numberOfStacks; i++)
            {
                positions[i] = i * "[X] ".Length + 1;
            }

            stacks = [];
            steps = [];
            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    isPlan = true;
                    continue;
                }

                if (isPlan)
                {
                    steps.Add(new Step(line));
                    continue;
                }

                for (int i = 0; i < positions.Length; i++)
                {
                    var character = line[positions[i]];
                    var stackIndex = i + 1;

                    if (char.IsWhiteSpace(character) || char.IsNumber(character))
                    {
                        continue;
                    }

                    if (stacks.TryGetValue(stackIndex, out Stack<char>? stack))
                    {
                        stack.Push(character);
                    }
                    else
                    {
                        Stack<char> newStack = [];
                        newStack.Push(character);
                        stacks[stackIndex] = newStack;
                    }
                }
            }

            // Reverse stacks to get the correct order
            foreach (var stack in stacks)
            {
                Stack<char> reversedStack = [];
                foreach (var character in stack.Value)
                {
                    reversedStack.Push(character);
                }

                stacks[stack.Key] = reversedStack;
            }
        }
    }
}
