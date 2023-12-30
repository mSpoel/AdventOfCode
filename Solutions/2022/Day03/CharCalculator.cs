namespace Day03
{
    internal static class CharCalculator
    {
        internal static int GetValue(char c)
        {
            if (char.IsUpper(c))
            {
                // Ascii A = 65 -> should map to 27
                return c - (65 - 27);
            }

            // Ascii a = 97 -> should map to 1
            return c - (97 - 1);
        }
    }
}
