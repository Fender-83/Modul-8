using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)

        {
            string path = @"C:\\Users\Fender\Desktop\Students";
            
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(path);

            BinaryFormatter formatter = new BinaryFormatter();
            Student[] students;

            using (var fs = new FileStream(@"C:\\Students.dat", FileMode.OpenOrCreate))
            {
                students = (Student[])formatter.Deserialize(fs);
            }
            Console.WriteLine("Папка 'Students' создана на 'Рабочем столе'");
            foreach (var student in students)
            {
                var path2 = $"C:\\Users\\Fender\\Desktop\\Students\\{student.Group}.txt";

                using (StreamWriter sw = File.AppendText(path2))
                {
                    sw.WriteLine($"{student.Name}, {student.DateOfBirth}");
                }
                Console.ReadLine();
            }
        }
    }
}