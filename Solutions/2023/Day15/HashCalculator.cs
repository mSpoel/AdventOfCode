namespace Day15
{
    internal static class HashCalculator
    {
        //Determine the ASCII code for the current character of the string.
        //Increase the current value by the ASCII code you just determined.
        //Set the current value to itself multiplied by 17.
        //Set the current value to the remainder of dividing itself by 256.
        internal static int CalculateHash(this string stringToHash)
        {
            var result = 0;

            foreach (char c in stringToHash)
            {
                result += c;
                result *= 17;
                result %= 256;
            }

            return result;
        }
    }
}