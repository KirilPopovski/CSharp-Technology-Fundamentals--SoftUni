using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dictionaries_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var starwars = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] parsed = input.Split(" | ");
                    if (!starwars.ContainsKey(parsed[1]))
                    {
                        starwars[parsed[1]] = parsed[0];
                    }
                }
                else if (input.Contains('>'))
                {
                    string[] parsed = input.Split(" -> ");
                    if (starwars.ContainsKey(parsed[0]))
                    {
                        starwars[parsed[0]] = parsed[1];
                        Console.WriteLine("{0} joins the {1} side!", parsed[0], parsed[1]);
                    }
                    else
                    {
                        starwars[parsed[0]] = parsed[1];
                        Console.WriteLine("{0} joins the {1} side!", parsed[0], parsed[1]);
                    }
                }
                input = Console.ReadLine();
            }
            var counts = new Dictionary<string, List<string>>();
            foreach(var item in starwars)
            {
                if (!counts.ContainsKey(item.Value))
                {
                    counts[item.Value] = new List<string>();
                }
                counts[item.Value].Add(item.Key);
            }
            foreach(var item in counts.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine("Side: {0}, Members: {1}", item.Key, item.Value.Count);
                foreach(var item2 in item.Value.OrderBy(x=>x))
                {
                    Console.WriteLine("! {0}", item2);
                }
            }
        }
    }
}
