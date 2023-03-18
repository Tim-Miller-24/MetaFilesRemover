using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MetaFilesDeleter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> folders = new List<string>();

            string metaFilesFormat = ".meta";
            string path = "";
            GetPath(ref path);

            folders.Add(path);
            folders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).ToList();

            for (int i = 0; i < folders.Count; i++)
            {
                foreach (var file in Directory.GetFiles(folders[i]))
                {
                    if (file.EndsWith(metaFilesFormat))
                    {
                        File.Delete(file);
                    }
                }
            }

            Console.WriteLine("Мета файлы успешно удалены \n");
        }

        static void GetPath(ref string path)
        {
            Console.WriteLine("Введите путь до папки");
            path = Console.ReadLine();
            
            if (!Directory.Exists(path))
            {
                GetPath(ref path);
            }
        }
    }
}
