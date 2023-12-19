
namespace Day19
{
    internal class MachineRule
    {
        private string _line;

        public MachineRule(string line)
        {
            _line = line;
            Name = _line.Split('{')[0];
            Expression = _line.Split('{')[1].Split('}')[0];
        }

        public string Name { get; internal set; }

        public string Expression { get; internal set; }

        internal string Evaluate(Parts parts)
        {
            var expressions = Expression.Split(',');

            foreach (var expression in expressions)
            {
                if (!IsEvalutation(expression))
                {
                    return expression;
                }

                if (EvaluateExpression(expression.Split(':')[0], parts))
                {
                    return expression.Split(':')[1];
                }
            }

            return "R";
        }

        private bool EvaluateExpression(string expression, Parts parts)
        {
            int valueToEvaluate = 0;
            valueToEvaluate = expression.Substring(0, 1) switch
            {
                "x" => parts.X,
                "m" => parts.M,
                "a" => parts.A,
                "s" => parts.S,
                _ => throw new Exception("Unknown expression"),
            };

            string compareOperator = expression.Substring(1, 1);
            int compareValue = int.Parse(expression[2..]);

            return compareOperator switch
            {
                ">" => valueToEvaluate > compareValue,
                "<" => valueToEvaluate < compareValue,
                "=" => valueToEvaluate == compareValue,
                _ => throw new Exception("Unknown compare operator"),
            };
        }

        private static bool IsEvalutation(string expression)
        {
            return expression.Contains('>') ||
                expression.Contains('<') ||
                expression.Contains('=');
        }
    }
}