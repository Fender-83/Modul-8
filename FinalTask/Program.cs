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
            BinaryFormatter formatter = new BinaryFormatter();
            Student[] students;

            using (var fs = new FileStream("Students.dat", FileMode.OpenOrCreate))
            {
                students = (Student[])formatter.Deserialize(fs);
            }
            Directory.CreateDirectory($"C:\\Students");
          
            foreach (var student in students)
            {
                var path = $"C:\\Students\\{student.Group}.txt";

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{student.Name}, {student.DateOfBirth}");
                }
                Console.ReadLine();
            }
        }
    }
}