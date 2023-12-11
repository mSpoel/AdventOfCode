namespace Day11
{
    internal class SolverPart2
    {
        internal long GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var galaxy = new GalaxyBuilder(lines).Build();
            //galaxy.Expand();
            //galaxy.WriteToConsole();

            var galaxies = galaxy.GetGalaxies();
            var rowsWithoutGalaxy = galaxy.RowsWithoutGalaxy();
            var columnsWithoutGalaxy = galaxy.ColumnsWithoutGalaxy();

            return GetDistances(galaxies, rowsWithoutGalaxy, columnsWithoutGalaxy);
        }

        internal long GetDistances(List<Coordinate> coordinates,
            List<int> rowsWithoutGalaxy,
            List<int> columnsWithoutGalaxy)
        {
            var distances = new List<long>();
            for (int i = 0; i < coordinates.Count; i++)
            {
                var distance = GetDistances(
                    coordinates[i],
                    coordinates.Skip(i + 1).ToList(),
                    rowsWithoutGalaxy,
                    columnsWithoutGalaxy);

                distances.Add(distance);
            }

            return distances.Sum();
        }

        internal long GetDistances(Coordinate coordinate,
            List<Coordinate> coordinates,
            List<int> rowsWithoutGalaxy,
            List<int> columnsWithoutGalaxy)
        {

            int numberOfEmptyRows = 1000000 - 1;
            var distances = new List<long>();

            Console.WriteLine($"Rows without galaxy {string.Join(",", rowsWithoutGalaxy)} Columns without galaxy {string.Join(",", columnsWithoutGalaxy)}");

            for (int i = 0; i < coordinates.Count; i++)
            {
                var nextCoordinate = coordinates[i];
                var distance = Distance(nextCoordinate, coordinate);

                Console.Write($"Distance between {coordinate} and {nextCoordinate} is {distance} \t");

                var startRow = Math.Min(coordinate.Row, nextCoordinate.Row);
                var rowSteps = Math.Abs(coordinate.Row - nextCoordinate.Row);
                var startColumn = Math.Min(coordinate.Column, nextCoordinate.Column);
                var columnSteps = Math.Abs(coordinate.Column - nextCoordinate.Column);

                int passedEmptyRows = 0;
                for (int row = startRow; row < startRow + rowSteps; row++)
                {
                    if (rowsWithoutGalaxy.Contains(row))
                    {
                        passedEmptyRows++;
                        distance += numberOfEmptyRows;
                    }
                }

                int passedEmptyColumns = 0;
                for (int column = startColumn; column < startColumn + columnSteps; column++)
                {
                    if (columnsWithoutGalaxy.Contains(column))
                    {
                        passedEmptyColumns++;
                        distance += numberOfEmptyRows;
                    }
                }

                Console.Write($"Total distance {distance} PassedEmptyRows: {passedEmptyRows} PassedEmptyColumns {passedEmptyColumns} \n");

                distances.Add(distance);
            }

            return distances.Sum();
        }

        internal long Distance(Coordinate coordinate1, Coordinate coordinate2)
        {
            return Math.Abs(coordinate1.Row - coordinate2.Row) + Math.Abs(coordinate1.Column - coordinate2.Column);
        }
    }
}
