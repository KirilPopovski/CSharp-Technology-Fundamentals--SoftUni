using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace oopPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[3];
            for(int i=0;i<3;i++)
            {
                students[i] = new Student(Console.ReadLine(), Console.ReadLine(), double.Parse(Console.ReadLine()));
            }
            foreach(var item in students.OrderBy(x => x.Sort(x.Mark)))
            {
                Console.WriteLine(item.Name + " " + item.LastName + " " + item.Mark);
            }
        }
    }
    class Human
    {
        private string name;
        private string lastName;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public Human(string name,string lastname)
        {
            this.name = name;
            lastName = lastname;
        }
    }
    class Student:Human,IComparable
    {
        private double mark;
        public double Mark
        {
            get { return this.mark; }
            set { this.mark = value; }
        }
        public Student(string name, string lastname,double mark) : base(name, lastname)
        {
            this.mark = mark;
        }
        public int CompareTo(object markkk)
        {
            if (mark > (double)markkk) return 1;
            else if (mark == (double)markkk) return 0;
            else return -1;
        }
        public bool Sort(double markkk)
        {
            if (markkk > mark) return true;
            else return false;
        }
    }
    class Worker : Human
    {
        private double nadnica;
        private int izraboteni;
        public Worker(string name, string lastname, double nadnica, int rabota) : base(name, lastname)
        {
            this.nadnica = nadnica;
            this.izraboteni = rabota;
        }
        public void calculateAverage()
        {
            Console.WriteLine(Name + LastName + " has {0:F2} sredna nadnica", nadnica / izraboteni);
        }
    }
}
