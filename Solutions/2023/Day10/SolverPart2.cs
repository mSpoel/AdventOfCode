
namespace Day10
{
    internal class SolverPart2
    {
        internal int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            var grid = new GridBuilder(lines).Build();

            //WriteGridToConsole(grid.NumberOfRows, grid.NumberOfColumns, new HashSet<Coordinate>(), grid);
            //Console.WriteLine();

            grid.Expand();


            //WriteGridToConsole(grid.NumberOfRows, grid.NumberOfColumns, new HashSet<Coordinate>(), grid);
            //Console.WriteLine();

            var startingPoint = grid.GetStartingPoint();

            var coordinatesToVisit = new Queue<Coordinate>();
            coordinatesToVisit.Enqueue(startingPoint);

            var coordinatesVisited = new HashSet<Coordinate>
            {
                startingPoint
            };

            while (coordinatesToVisit.Count > 0)
            {
                var currentCoordinate = coordinatesToVisit.Dequeue();
                var currentGridItem = grid.GetGridItem(currentCoordinate);

                var neighbours = grid.GetNeighbours(currentCoordinate);

                foreach (var neighbour in neighbours)
                {
                    if (coordinatesVisited.Contains(neighbour))
                    {
                        continue;
                    }
                    coordinatesToVisit.Enqueue(neighbour);
                }

                coordinatesVisited.Add(currentCoordinate);
            }

            //WriteGridToConsole(grid.NumberOfRows, grid.NumberOfColumns, coordinatesVisited, grid);
            //Console.WriteLine();

            var array = ToArray(grid, coordinatesVisited);

            //WriteArrayToConsole(array, new List<Coordinate>(), new List<int>());
            //Console.WriteLine();

            var algorithm = new FloodFillAlgorithm();

            int row = 0;
            int column = 0;
            int color = 2;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] == 0)
                    {
                        row = i;
                        column = j;

                        algorithm.FloodFill(array, row, column, color++);

                        //Console.WriteLine($"Color: {color}");
                        //WriteArrayToConsole(array, new List<Coordinate>(), new List<int>(), true);
                        //Console.WriteLine();
                    }
                }
            }

            WriteArrayToConsole(array, new List<Coordinate>(), new List<int>());

            List<int> colorsOnEdge = new List<int>();
            for (int i = 0; i < grid.NumberOfRows; i++)
            {
                if (array[i][0] > 1 && !colorsOnEdge.Contains(array[i][0]))
                {
                    colorsOnEdge.Add(array[i][0]);
                }
            }

            for (int i = 0; i < grid.NumberOfRows; i++)
            {
                if (array[i][grid.NumberOfColumns - 1] > 1 && !colorsOnEdge.Contains(array[i][grid.NumberOfColumns - 1]))
                {
                    colorsOnEdge.Add(array[i][grid.NumberOfColumns - 1]);
                }
            }

            for (int i = 0; i < grid.NumberOfColumns; i++)
            {
                if (array[0][i] > 1 && !colorsOnEdge.Contains(array[0][i]))
                {
                    colorsOnEdge.Add(array[0][i]);
                }
            }

            for (int i = 0; i < grid.NumberOfColumns; i++)
            {
                if (array[grid.NumberOfRows - 1][i] > 1 && !colorsOnEdge.Contains(array[grid.NumberOfRows - 1][i]))
                {
                    colorsOnEdge.Add(array[grid.NumberOfRows - 1][i]);
                }
            }

            List<Coordinate> coordinates = new List<Coordinate>();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (!colorsOnEdge.Contains(array[i][j])
                        && array[i][j] > 2)
                    {
                        coordinates.Add(new Coordinate(i, j));
                    }
                }
            }

            var result = 0;
            foreach (var coordinate in coordinates)
            {
                if (!grid.IsExpanded(coordinate.Row, coordinate.Column))
                {
                    result++;
                }
            }

            WriteArrayToConsole(array, coordinates, colorsOnEdge);

            return result;
        }

        private static void WriteGridToConsole(int numberOfRows, int numberOfColumns, HashSet<Coordinate> coordinatesVisited, Grid grid)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    var coordinate = new Coordinate(row, column);
                    if (coordinatesVisited.Contains(coordinate))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = foregroundColor;
                    }

                    Console.Write(grid.GetGridItem(coordinate).Symbol);
                }
                Console.Write("\n");
            }
        }

        private int[][] ToArray(Grid grid, HashSet<Coordinate> coordinatesToColor)
        {
            var array = new int[grid.NumberOfRows][];

            for (int row = 0; row < grid.NumberOfRows; row++)
            {
                array[row] = new int[grid.NumberOfColumns];
                for (int column = 0; column < grid.NumberOfColumns; column++)
                {
                    var coordinate = new Coordinate(row, column);
                    var gridItem = grid.GetGridItem(coordinate);

                    if (coordinatesToColor.Contains(coordinate))
                    {
                        array[row][column] = 1;
                    }
                    else
                    {
                        array[row][column] = 0;
                    }
                }
            }

            return array;
        }

        private static void WriteArrayToConsole(int[][] array, List<Coordinate> coordinates, List<int> colorsOnEdge, bool showColor = false)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            for (int row = 0; row < array.Length; row++)
            {
                for (int column = 0; column < array[row].Length; column++)
                {
                    var coordinate = new Coordinate(row, column);
                    if (array[row][column] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (array[row][column] > 1)
                    {
                        if (colorsOnEdge.Contains(array[row][column]))
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        else
                        {
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = foregroundColor;
                    }

                    if (coordinates.Contains(coordinate))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    if (showColor)
                    {
                        Console.Write(array[row][column]);
                        continue;
                    }

                    if (array[row][column] > 1)
                    {
                        Console.Write("2");
                    }
                    else
                    {
                        Console.Write(array[row][column]);
                    }
                }
                Console.Write("\n");
            }
        }
    }
}