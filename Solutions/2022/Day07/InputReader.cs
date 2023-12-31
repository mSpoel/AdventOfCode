namespace Day07
{
    internal static class InputReader
    {
        internal static Directory Process(string[] lines)
        {
            Directory workingDirectory = new("/", null!);

            foreach (var line in lines)
            {
                if (line.StartsWith('$'))
                {
                    //command
                    var formattedLine = line.Remove(0, 2); //Remove the '$ '
                    if (formattedLine.StartsWith("ls"))
                    {
                        // Get the directory information
                        continue;
                    }
                    else if (formattedLine.StartsWith("cd .."))
                    {
                        // Go up one directory
                        workingDirectory = workingDirectory.ParentDirectory;
                        continue;
                    }
                    else if (formattedLine.StartsWith("cd "))
                    {
                        // Change to the specified directory
                        var directoryName = formattedLine.Remove(0, 3);

                        if (directoryName == "/")
                        {
                            continue;
                        }

                        var directory = new Directory(directoryName, workingDirectory);
                        workingDirectory.Directories.Add(directory);
                        workingDirectory = directory;
                    }
                }
                else
                {
                    //output
                    if (char.IsNumber(line[0]))
                    {
                        //File
                        var size = int.Parse(line.Split(' ')[0]);
                        var name = line.Split(' ')[1];
                        var file = new File(name, size);

                        workingDirectory.Files.Add(file);
                    }
                    else
                    {
                        //Directory
                        continue;
                    }
                }
            }

            // Go to the root directory
            while (workingDirectory.ParentDirectory != null)
            {
                workingDirectory = workingDirectory.ParentDirectory;
            }

            return workingDirectory;
        }
    }
}
