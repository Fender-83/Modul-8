using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalTask
{
    internal class Program
    {
        [Serializable]
        class Students
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Students(string name, string group, DateTime dateOfBirth)
            {
                Name = name;
                Group = group;
                DateOfBirth = dateOfBirth;
            }
        }

        static void Main(string[] args)
        {
            string path = @"C:\\Users\";
            string subpath = @"Fender\Desktop\Students";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            Console.WriteLine("Папка 'Students' создана на 'Рабочем Столе'");

            string filePath = @"C:\\Students.dat";
            if (File.Exists(filePath))
            {
                string stringValue;
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    stringValue = reader.ReadString();
                }
            }
            using (BinaryReader reader = new BinaryReader(File.Open(@"C:\\Students.dat", FileMode.Open)))
            {
                string Name = reader.ReadString();
                string Group = reader.ReadString();
                string DateOfBirth = reader.ReadString();
            }
        }
    }
}
