using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if(!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }
                students[name].Add(grade);
            }
            foreach(var item in students.OrderByDescending(x=>x.Value.Average()))
            {
                if (item.Value.Average() >= 4.5) Console.WriteLine("{0} -> {1:F2}", item.Key, item.Value.Average());
            }
        }
    }
}
