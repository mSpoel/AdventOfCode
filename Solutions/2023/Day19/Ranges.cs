namespace Day19
{
    public static class Ranges
    {
        public static List<Range> GetPassRanges(string expression, Range range)
        {
            List<Range> ranges = [];

            string compareOperator = expression.Substring(1, 1);
            int compareValue = int.Parse(expression[2..]);

            switch (compareOperator)
            {
                case ">":
                    if (range.End.Value > compareValue)
                    {
                        ranges.Add(new Range(Math.Max(range.Start.Value, compareValue + 1), range.End.Value));
                    }
                    break;
                case "<":
                    if (range.Start.Value < compareValue)
                    {
                        ranges.Add(new Range(range.Start.Value, Math.Min(range.End.Value, compareValue - 1)));
                    }
                    break;
                case "=":
                    if (range.Start.Value >= compareValue && range.End.Value <= compareValue)
                    {
                        ranges.Add(new Range(compareValue, compareValue));
                    }
                    break;
                default:
                    throw new Exception("Unknown compare operator");
            }

            return ranges;
        }

        public static List<Range> GetFailRanges(string expression, Range range)
        {
            List<Range> ranges = [];

            string compareOperator = expression.Substring(1, 1);
            int compareValue = int.Parse(expression[2..]);

            switch (compareOperator)
            {
                case ">":
                    if (range.Start.Value <= compareValue)
                    {
                        ranges.Add(new Range(range.Start.Value, Math.Min(compareValue, range.End.Value)));
                    }
                    break;
                case "<":
                    if (range.End.Value >= compareValue)
                    {
                        ranges.Add(new Range(Math.Max(compareValue, range.Start.Value), range.End.Value));
                    }
                    break;
                case "=":
                    if (range.Start.Value >= compareValue && range.End.Value <= compareValue)
                    {
                        ranges.Add(new Range(range.Start.Value, compareValue - 1));
                        ranges.Add(new Range(compareValue + 1, range.End.Value));
                    }
                    break;
                default:
                    throw new Exception("Unknown compare operator");
            }

            return ranges;
        }
    }
}
