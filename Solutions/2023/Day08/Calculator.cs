namespace Day08
{
    public class Calculator
    {
        /// <summary>
        /// Get the greatest common divisor of two numbers
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        public static long Gcd(long number1, long number2)
        {
            if (number2 == 0)
            {
                return number1;
            }
            else
            {
                return Gcd(number2, number1 % number2);
            }
        }

        /// <summary>
        /// Get the least common multiple of an array of numbers
        /// </summary>
        /// <param name="numbers"></param>
        public static long Lcm(long[] numbers)
        {
            return numbers.Aggregate((number, val) => number * val / Gcd(number, val));
        }
    }
}
