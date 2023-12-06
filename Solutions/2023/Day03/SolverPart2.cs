namespace Day03
{
    internal class SolverPart2
    {
        public int GetSolution(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);

            List<Digit> digits = new List<Digit>();
            List<Gear> gears = new List<Gear>();

            for (int i = 0; i < lines.Length; i++)
            {
                var lineDigits = new LineDigits(lines[i], i);
                digits.AddRange(lineDigits.GetDigits());

                var lineGears = new LineGears(lines[i], i);
                gears.AddRange(lineGears.GetGears());
            }

            int result = 0;
            var gearCalculator = new GearCalculator(lines, digits);
            foreach(var gear in gears)
            {
                Console.Write($"Gear: {gear.LineNumber}, {gear.Index} \t");
                result += gearCalculator.GetValue(gear);
                Console.WriteLine();
            }


            return result;
        }
    }
}
