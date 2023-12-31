namespace Day07
{
    internal class File(string name, int size)
    {
        public int Size { get; } = size;

        public string Name { get; } = name;
    }
}
