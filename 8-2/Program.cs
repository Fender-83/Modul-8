using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_2
{
    internal class Program
    {
        public static double GetSize(DirectoryInfo directory)
        {
            double summByte = 0;
            try
            {
                if (directory.Exists)
                {
                    foreach (var file in directory.GetFiles())
                    {
                        summByte += file.Length;
                    }
                    foreach (var folder in directory.GetDirectories())
                    {
                        summByte += GetSize(folder);
                    }
                    return summByte;
                }
                else
                {
                    Console.WriteLine("По данному пути папки не существует");
                    return summByte;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return summByte;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь ");
            string path = Console.ReadLine();
            var folder = new DirectoryInfo(path);
            double result = GetSize(folder);
            if (folder.Exists)
            {
                Console.WriteLine("Размер папки на диске составляет " + result + " байт");
            }
        }
    }
}
