
using System.Collections.Immutable;
using Cache = System.Collections.Generic.Dictionary<(string, System.Collections.Immutable.ImmutableStack<int>), long>;

namespace Day12
{
    internal class SpringRow
    {
        private readonly string _line;
        private readonly string _springs;
        private readonly ImmutableStack<int> _groups = [];

        public SpringRow(string line)
        {
            _line = line;
            _springs = line.Split(" ")[0];
            foreach (var group in line.Split(" ")[1].Split(",").Reverse())
            {
                _groups = _groups.Push(int.Parse(group));
            }
        }

        internal long GetNumberOfCombinations()
        {
            //Console.WriteLine($"Start GetNumberOfCombinations Pattern: {_springs}, Groups: {string.Join(",", _groups)}");
            return GetNumberOfCombinations(_springs, _groups, new Cache());
        }

        internal long GetNumberOfCombinations(string pattern, ImmutableStack<int> groups, Cache cache)
        {
            //Console.WriteLine($"Pattern: {pattern}, Groups: {string.Join(",", groups)}");
            if (!cache.ContainsKey((pattern, groups)))
            {
                cache[(pattern, groups)] = CalculateNumberOfCombinations(pattern, groups, cache);
            }

            return cache[(pattern, groups)];
        }

        private long CalculateNumberOfCombinations(string pattern, ImmutableStack<int> groups, Cache cache)
        {
            //Console.WriteLine($"CalculateNumberOfCombinations Pattern: {pattern}, Groups: {string.Join(",", groups)}");
            return pattern.FirstOrDefault() switch
            {
                '#' => ProcessHash(pattern, groups, cache),
                '.' => ProcessDot(pattern, groups, cache),
                '?' => ProcessQuestionMark(pattern, groups, cache),
                _ => ProcessEnd(pattern, groups, cache)
            };
        }

        private long ProcessEnd(string pattern, ImmutableStack<int> groups, Cache cache)
        {
            //Console.WriteLine($"ProcessEnd Pattern: {pattern}, Groups: {string.Join(",", groups)}");
            // We reached the end of the pattern, so we need to check if we have any groups left
            return groups.Any() ? 0 : 1;
        }

        private long ProcessQuestionMark(string pattern, ImmutableStack<int> groups, Cache cache)
        {
            //Console.WriteLine($"ProcessQuestionMark Pattern: {pattern}, Groups: {string.Join(",", groups)}");
            return ProcessDot('.' + pattern[1..], groups, cache) + ProcessHash('#' + pattern[1..], groups, cache);
        }

        private long ProcessDot(string pattern, ImmutableStack<int> groups, Cache cache)
        {
            //Console.WriteLine($"ProcessDot Pattern: {pattern}, Groups: {string.Join(",", groups)}");
            return GetNumberOfCombinations(pattern[1..], groups, cache);
        }

        private long ProcessHash(string pattern, ImmutableStack<int> groups, Cache cache)
        {
            if (!groups.Any())
            {
                return 0;
            }

            int number = groups.Peek();
            groups = groups.Pop();

            var count = pattern.TakeWhile(s => s == '#' || s == '?').Count();

            if (count < number)
            {
                // We don't have enough characters to fill the group
                return 0;
            }
            else if (pattern.Length == number)
            {
                // We reached the end of the pattern, so we need to check if we have any groups left
                return GetNumberOfCombinations("", groups, cache);
            }
            else if (pattern[number] == '#')
            {
                // Next is a spring, that is wrong
                return 0;
            }
            else
            {
                return GetNumberOfCombinations(pattern[(number + 1)..], groups, cache);
            }
        }
    }
}