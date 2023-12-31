namespace Day06
{
    public static class BufferProcessor
    {
        public static int GetFirstMarkerPosition(string input, int stringToCheckLength)
        {
            int end = input.Length - 1 - stringToCheckLength;

            for (int i = 0; i < end; i++)
            {
                string toCheck = input.Substring(i, stringToCheckLength);

                bool isMarker = true;
                foreach (var character in toCheck)
                {
                    if (toCheck.Count(c => c == character) > 1)
                    {
                        isMarker = false;
                        break;
                    }
                }

                if (isMarker)
                {
                    return i + stringToCheckLength;
                }
            }

            return -1;
        }
    }
}
