using System.IO;
using laba4;

void FileSystemWatcher_Change(string date, string[] arrayChanges)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"\nDate: {date}");
    foreach (var item in arrayChanges)
    {
        Console.WriteLine($"{item}");
    }

    Console.ResetColor();
};
var PathForFolder = "C:\\Users\\zebra\\Desktop\\myHomework\\BMSTU-Lab-C-sharp\\laba4-delegates-event\\test-files";
laba4.FileSystemWatcher fileSystemWatcher = new laba4.FileSystemWatcher(PathForFolder);

fileSystemWatcher.Change += FileSystemWatcher_Change;

Console.Read();