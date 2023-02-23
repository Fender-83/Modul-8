using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeleteFileTryCach("C:\\Test\\");
        }

        public static void DeleteFile(string path)
        {
            var directory = new DirectoryInfo(path);
            if (directory.Exists)
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                    TimeSpan timeSpan = TimeSpan.FromMinutes(30);
                    TimeSpan timeSpanFile = (DateTime.Now - file.LastAccessTime);

                    if (timeSpanFile > timeSpan)
                    {

                        file.Delete();
                    }
                }
            }
            else
            {
                Console.WriteLine("Такой папки не существует");
            }
        }

        public static void DeleteFileTryCach(string path)
        {
            var directory = new DirectoryInfo(path);
            try
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                    TimeSpan timeSpan = TimeSpan.FromMinutes(30);
                    TimeSpan timeSpanFile = (DateTime.Now - file.LastAccessTime);

                    if (timeSpanFile > timeSpan)
                    {
                        file.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
