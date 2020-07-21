using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);
            var extensionFileInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                var info = new FileInfo(file);
                var extension = info.Extension;

                if (!extensionFileInfo.ContainsKey(extension))
                {
                    extensionFileInfo.Add(extension, new List<FileInfo>());
                }

                extensionFileInfo[extension].Add(info);
            }

            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            using (StreamWriter writer = new StreamWriter(pathToDesktop))
            {
                foreach (var kvp in extensionFileInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    string ext = kvp.Key;
                    var info = kvp.Value;

                    writer.WriteLine(ext);

                    foreach (var fileInfo in info.OrderByDescending(x => x.Length))
                    {
                        string name = fileInfo.Name;
                        double size = fileInfo.Length / 1024;

                        writer.WriteLine($"--{name} - {size:f3}kb");
                    }
                }
            }
        }
    }
}

