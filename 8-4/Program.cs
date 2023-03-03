using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace FinalTask
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }

    internal class Program
    {
       
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
            SoapFormatter formatter = new SoapFormatter();
         
            using (var fileStream = new FileStream(@"C:\Students.dat", FileMode.OpenOrCreate))
            {
                var student = (Student)formatter.Deserialize(fileStream);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {student.Name} --- Возраст: {student.DateOfBirth}");
            }
            Console.ReadLine();


        }
    }
}
