
using Day11;

internal class SolverPart1
{
    internal int GetSolution(string inputPath)
    {
        string[] lines = File.ReadAllLines(inputPath);

        var galaxy = new GalaxyBuilder(lines).Build();
        galaxy.WriteToConsole();

        var galaxies = galaxy.GetGalaxies();
        var rowsWithoutGalaxy = galaxy.RowsWithoutGalaxy();
        var columnsWithoutGalaxy = galaxy.ColumnsWithoutGalaxy();

        return GetDistances(galaxies, rowsWithoutGalaxy, columnsWithoutGalaxy);
    }

    internal int GetDistances(List<Coordinate> coordinates,
        List<int> rowsWithoutGalaxy,
        List<int> columnsWithoutGalaxy)
    {
        var distances = new List<int>();
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

    internal int GetDistances(Coordinate coordinate,
        List<Coordinate> coordinates,
        List<int> rowsWithoutGalaxy,
        List<int> columnsWithoutGalaxy)
    {
        var distances = new List<int>();
        for (int i = 0; i < coordinates.Count; i++)
        {
            var nextCoordinate = coordinates[i];
            var distance = Distance(nextCoordinate, coordinate);

            var startRow = Math.Min(coordinate.Row, nextCoordinate.Row);
            var rowSteps = Math.Abs(coordinate.Row - nextCoordinate.Row);
            var startColumn = Math.Min(coordinate.Column, nextCoordinate.Column);
            var columnSteps = Math.Abs(coordinate.Column - nextCoordinate.Column);

            for (int row = startRow; row < startRow + rowSteps; row++)
            {
                if (rowsWithoutGalaxy.Contains(row))
                {
                    distance++;
                }
            }

            for (int column = startColumn; column < startColumn + columnSteps; column++)
            {
                if (columnsWithoutGalaxy.Contains(column))
                {
                    distance++;
                }
            }

            distances.Add(distance);
        }

        return distances.Sum();
    }

    internal int Distance(Coordinate coordinate1, Coordinate coordinate2)
    {
        return Math.Abs(coordinate1.Row - coordinate2.Row) + Math.Abs(coordinate1.Column - coordinate2.Column);
    }
}
