namespace Day03
{
    internal static class CharCalculator
    {
        internal static int GetValue(char c)
        {
#pragma warning disable CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
            if (c.ToString().ToUpper() == c.ToString())
            {
                // Ascii A = 65 -> should map to 27
                return c - (65 - 27);
            }
#pragma warning restore CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons

            // Ascii a = 97 -> should map to 1
            return c - (97 - 1);
        }
    }
}
