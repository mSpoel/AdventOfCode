using System.Text.RegularExpressions;

namespace Day04
{
    internal class Card
    {
        public Card(string line)
        {
            CardNumber = GetCardNumber(line.Split(':')[0]);
            WinningNumbers = GetNumbers(line.Split(':')[1].Split('|')[0]);
            OwnNumbers = GetNumbers(line.Split(':')[1].Split('|')[1]);
        }

        public int CardNumber { get; }

        public List<int> WinningNumbers { get; set; }

        public List<int> OwnNumbers { get; set; }

        private int GetCardNumber(string cardNumberAsString)
        {
            var digit = Regex.Match(cardNumberAsString, @"\d+");

            return int.Parse(digit.Value);
        }

        private List<int> GetNumbers(string numbersAsString)
        {
            var result = new List<int>();

            var digits = Regex.Matches(numbersAsString, @"\d+");

            digits.ToList().ForEach(x => result.Add(int.Parse(x.Value)));

            return result;
        }

        public override string ToString()
        {
            return $"Card {CardNumber} - Winning {string.Join(",", WinningNumbers)} - Own {string.Join(",", OwnNumbers)}";
        }
    }
}
