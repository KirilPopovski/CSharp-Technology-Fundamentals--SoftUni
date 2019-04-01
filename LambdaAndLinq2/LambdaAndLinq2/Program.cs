using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaAndLinq2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("kiril", "popovski", 20));
            students.Add(new Student("anna", "brezova", 20));
            students.Add(new Student("sasho", "dimitrov", 20));
            students.Add(new Student("petq", "tancheva", 20));
            foreach(var item in students.Where(x=>x.Age>=18 && x.Age<=19))
            {
                Console.WriteLine(item.lastName + item.Name + item.Age.ToString());
            }
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public string lastName { get; set; }
        public int Age { get; set; }
        public Student(string name,string lastname,int age)
        {
            this.Name = name;
            this.lastName = lastname;
            this.Age = age;
        }
    }
}
