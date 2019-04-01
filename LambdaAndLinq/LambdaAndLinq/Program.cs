using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaAndLinq
{
    class Program
    {

        static void Main(string[] args)
        {
            var str = new StringBuilder();
            str.Append(Console.ReadLine());
            Console.WriteLine(str.Substring(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        }
        
    }
    public static class StringExtension
    {
        public static StringBuilder Substring(this StringBuilder str,int index,int lenght)
        {
            var str2 = new StringBuilder();
            for(int i=index;i<index+lenght;i++)
            {
                str2.Append(str[i]);
            }
            return str2;
        }
    }
}
