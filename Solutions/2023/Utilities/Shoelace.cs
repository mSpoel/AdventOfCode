namespace Utilities
{
    public static class Shoelace
    {
        //https://en.wikipedia.org/wiki/Shoelace_formula
        public static long GetArea(List<Coordinate2D> coordinates)
        {
            long area = 0;

            for (int i = 0; i < coordinates.Count; i++)
            {
                int j = (i + 1) % coordinates.Count;

                area += coordinates[i].Row * coordinates[j].Column;
                area -= coordinates[i].Column * coordinates[j].Row;
            }

            return Math.Abs(area / 2);
        }
    }
}
