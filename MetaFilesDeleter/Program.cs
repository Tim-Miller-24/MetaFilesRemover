using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MetaFilesDeleter
{
    class Program
    {
        static void Main()
        {
            List<string> folders;

            string metaFilesFormat = ".meta";
            string path;

            path = GetPath();

            folders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).ToList();
            folders.Add(path);

            foreach (var folder in folders)
            {
                foreach (var file in Directory.GetFiles(folder))
                {
                    if (file.EndsWith(metaFilesFormat))
                    {
                        File.Delete(file);
                    }
                }
            }

            Console.WriteLine("Мета файлы успешно удалены \n");
        }

        static string GetPath()
        {
            string path;
            do
            {
                Console.WriteLine("Введите путь до папки");
                path = Console.ReadLine();

            } while (!Directory.Exists(path));

            return path;
        }
    }
}
