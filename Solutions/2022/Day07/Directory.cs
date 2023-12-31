
namespace Day07
{
    internal class Directory(string name, Directory parentDirectory)
    {
        public List<Directory> Directories = [];

        public List<File> Files = [];

        public string Name { get; } = name;

        public Directory ParentDirectory { get; } = parentDirectory;

        internal int GetTotalSize()
        {
            return Files.Sum(f => f.Size) + Directories.Sum(d => d.GetTotalSize());
        }
    }
}
