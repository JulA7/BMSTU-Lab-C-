using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    public class FileSystemWatcher
    {
        private string[] prevFiles;
        private Dictionary<string, DateTime> dictionaryChanges = new Dictionary<string, DateTime>();
        private string[] prevDirectories;

        private string path;
        private Timer timer;

        public delegate void WatchHandler(string date, string[] arrayChanges);
        WatchHandler? change;
        public event WatchHandler Change
        {
            add
            {
                var countInvocationItems = change?.GetInvocationList()?.Length;

                change += value;
                Console.WriteLine($"{value.Method.Name} добавлен countInvocationItems={countInvocationItems} timer={timer}");

                if (timer == null)
                {
                    // Устанавливаем метод обратного вызова
                    TimerCallback tm = new TimerCallback(CheckFiles);
                    // Создаем таймер
                    timer = new Timer(tm, null, 0, 5_000);
                }
            }
            remove
            {
                change -= value;
                Console.WriteLine($"{value.Method.Name} удален");

                var countInvocationItems = change.GetInvocationList().Length;
                if (countInvocationItems == 0)
                {
                    timer.Dispose();
                    timer = null;

                    dictionaryChanges = new Dictionary<string, DateTime>();
                    prevFiles = null;
                    prevDirectories = null;
                }
            }
        }

        public FileSystemWatcher(string readPath)
        {
            path = readPath;
        }

        private void CheckFiles(object obj)
        {
            var files = Directory.GetFiles(path);
            var directories = Directory.GetDirectories(path);

            Console.WriteLine("\nСчитаный файлы");
            foreach (var file in files) Console.WriteLine($"file >> {file} {Directory.GetLastWriteTime(file)}");
            foreach (var directory in directories) Console.WriteLine($"directory >> {directory}");

            if (prevFiles != null && prevDirectories != null)
            {
                var deletedFiles = prevFiles.Except(files);
                var addedFiles = files.Except(prevFiles);

                var deletedDirectories = prevDirectories.Except(directories);
                var addedDirectories = directories.Except(prevDirectories);

                var changedFilesList = new List<string>();
                foreach (var file in files)
                {
                    try
                    {
                        var prevTime = dictionaryChanges[file];
                        var newTime = Directory.GetLastWriteTime(file);
                        if (!prevTime.Equals(newTime)) changedFilesList.Add(file);
                    }
                    catch (Exception ex) { }

                }
                var changedFiles = changedFilesList.ToArray();

                var resultsList = new List<string>();

                foreach (var directory in deletedDirectories) resultsList.Add($"Удалена директория: {directory}");
                foreach (var directory in addedDirectories) resultsList.Add($"Добавлена директория: {directory}");

                foreach (var file in deletedFiles) resultsList.Add($"Удален файл: {file}");
                foreach (var file in addedFiles) resultsList.Add($"Добавлен файл: {file}");
                foreach (var file in changedFiles) resultsList.Add($"Измен файл: {file}");

                if (resultsList.Count > 0) change?.Invoke(DateTime.Now.ToString(), resultsList.ToArray());

            }

            prevFiles = files;
            prevDirectories = directories;
            foreach (var file in files)
            {
                try
                {
                    dictionaryChanges.Remove(file);
                    dictionaryChanges.Add(file, Directory.GetLastWriteTime(file));
                }
                catch (Exception ex) { }
            }
        }
    }
}
