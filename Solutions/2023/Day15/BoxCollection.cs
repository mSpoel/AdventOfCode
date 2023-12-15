namespace Day15
{
    internal class BoxCollection
    {
        private readonly List<string>[] _boxes;

        private readonly Dictionary<string, int> _lensFocus = new Dictionary<string, int>();

        internal BoxCollection()
        {
            _boxes = new List<string>[256];
            for (int i = 0; i < 256; i++)
            {
                _boxes[i] = [];
            }
        }

        internal void Process(string part)
        {
            if (part.Contains('-'))
            {
                Remove(part.Split('-')[0]);
            }
            else
            {
                var parts = part.Split('=');
                Add(parts[0], int.Parse(parts[1]));
            }
        }

        public int Calculate()
        {
            int result = 0;

            for (int i = 0; i < _boxes.Length; i++)
            {
                for (int j = 0; j < _boxes[i].Count; j++)
                {
                    var item = _boxes[i][j];
                    var boxResult = (i + 1) * (j + 1) * _lensFocus[item];
                    Console.WriteLine($"{item}: (box {i}) * {i + 1} (box {i}) * {j + 1} (slot) * {_lensFocus[item]} (focal length) = {boxResult}");
                    result += boxResult;
                }
            }

            return result;
        }

        private void Add(string label, int value)
        {
            var hash = label.CalculateHash();
            var box = _boxes[hash];

            if (!box.Contains(label))
            {
                box.Add(label);
            }

            if (!_lensFocus.ContainsKey(label))
            {
                _lensFocus.Add(label, value);
            }

            _lensFocus[label] = value;

        }

        private void Remove(string label)
        {
            var hash = label.CalculateHash();
            _boxes[hash].Remove(label);
        }
    }
}