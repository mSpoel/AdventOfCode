
namespace Day06
{
    internal class RaceCalculator
    {
        internal static int CalculateWinningOptions(Race race)
        {
            var nummberOfWins = 0;

            for (int i = 0; i <= race.Time; i++)
            {
                var distanceTraveled = i * (race.Time - i);

                if (distanceTraveled > race.Record)
                {
                    nummberOfWins++;
                }
            }

            return nummberOfWins;
        }
    }
}