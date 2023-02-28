using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_3
{
    internal class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine("Введите путь к папке ");
                DeleteFile(Console.ReadLine());
            }
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
            public static void DeleteFile(string path)
            {
                int result = 0;
                var directory = new DirectoryInfo(path);
                double sizeBefore = 0;
                double sizeAfter = 0;
                if (directory.Exists)
                {
                    sizeBefore = GetSize(directory);
                    Console.WriteLine("Исходный размер составляет " + sizeBefore + " байт");


                    foreach (FileInfo file in directory.GetFiles())
                    {
                        TimeSpan timeSpan = TimeSpan.FromMinutes(30);
                        TimeSpan timeSpanFile = (DateTime.Now - file.LastAccessTime);

                        if (timeSpanFile > timeSpan)
                        {

                            file.Delete();
                            result += 1;
                        }
                    }
                    sizeAfter = GetSize(directory);
                    Console.WriteLine("Освобождено места на диске " + (sizeBefore - sizeAfter) + " байт");
                    Console.WriteLine("Файлов удалено " + result + " шт.");
                    Console.WriteLine("Папка весит после очистки " + sizeAfter + " байт");
                }
                else
                {
                    Console.WriteLine("Такой папки не существует");
                }
            }
        }
    }