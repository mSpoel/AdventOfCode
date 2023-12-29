namespace Day02
{
    internal class RockPaperScissorsEngine
    {
        private readonly Dictionary<char, Choice> _choices = new()
        {
            { 'A', Choice.Rock },
            { 'B', Choice.Paper },
            { 'C', Choice.Scissors },
            { 'X', Choice.Rock },
            { 'Y', Choice.Paper },
            { 'Z', Choice.Scissors}
        };

        private readonly Dictionary<Choice, int> _scores = new()
        {
            { Choice.Rock, 1 },
            { Choice.Paper, 2 },
            { Choice.Scissors, 3 }
        };

        private readonly Dictionary<GameResult, int> _results = new()
        {
            { GameResult.Win, 6 },
            { GameResult.Loss, 0 },
            { GameResult.Draw, 3 }
        };

        private readonly Dictionary<char, GameResult> _gameResults = new()
        {
            { 'X', GameResult.Loss },
            { 'Y', GameResult.Draw },
            { 'Z', GameResult.Win }
        };

        internal int GetScore(string line)
        {
            var parts = line.Split(' ');

            var opponentChoice = _choices[parts[0][0]];
            var myChoice = _choices[parts[1][0]];

            var result = GetResult(myChoice, opponentChoice);

            return _results[result] + _scores[myChoice];
        }

        internal int GetScorePart2(string line)
        {
            var parts = line.Split(' ');

            var opponentChoice = _choices[parts[0][0]];
            var gameResult = _gameResults[parts[1][0]];

            Choice myChoice = DetermineMyChoice(opponentChoice, gameResult);

            return _results[gameResult] + _scores[myChoice];
        }

        private static Choice DetermineMyChoice(Choice opponentChoice, GameResult gameResult)
        {
            if (gameResult == GameResult.Draw)
            {
                return opponentChoice;
            }

            if (gameResult == GameResult.Win)
            {
                return opponentChoice switch
                {
                    Choice.Rock => Choice.Paper,
                    Choice.Paper => Choice.Scissors,
                    Choice.Scissors => Choice.Rock,
                    _ => throw new Exception("Invalid opponent choice"),
                };
            }

            return opponentChoice switch
            {
                Choice.Rock => Choice.Scissors,
                Choice.Paper => Choice.Rock,
                Choice.Scissors => Choice.Paper,
                _ => throw new Exception("Invalid opponent choice"),
            };
        }

        internal static GameResult GetResult(Choice myChoice, Choice opponentChoice)
        {
            if (myChoice == opponentChoice)
            {
                return GameResult.Draw;
            }

            if (myChoice == Choice.Rock && opponentChoice == Choice.Scissors)
            {
                return GameResult.Win;
            }

            if (myChoice == Choice.Paper && opponentChoice == Choice.Rock)
            {
                return GameResult.Win;
            }

            if (myChoice == Choice.Scissors && opponentChoice == Choice.Paper)
            {
                return GameResult.Win;
            }

            return GameResult.Loss;
        }
    }
}