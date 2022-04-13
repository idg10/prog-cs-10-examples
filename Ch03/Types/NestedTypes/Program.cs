using NestedTypes;

// Ask the class library where the user's My Documents folder lives
string path =
    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
string[] files = FileSorter.GetByNameLength(path);
foreach (string file in files)
{
    Console.WriteLine(file);
}
