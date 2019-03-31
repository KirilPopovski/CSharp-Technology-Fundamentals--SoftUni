using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays_exersize
{
    class Program
    {
        static void Main(string[] args)
        {
            string parser = Console.ReadLine();
            string[] buff = parser.Split(' ');
            int[] arr1 = new int[buff.Length];
            for(int i=0;i<buff.Length;i++)
            {
                arr1[i] = int.Parse(buff[i]);
            }
            int n = int.Parse(Console.ReadLine());
            for(int i =0;i<arr1.Length;i++)
            {
                for(int j=i;j<arr1.Length;j++)
                {
                    if (arr1[i] + arr1[j] == n && i != j) Console.WriteLine(arr1[i] + " " + arr1[j]);
                }
            }
            Console.ReadKey();
            
        }
    }
}
