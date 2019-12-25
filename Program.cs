using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace forMitrev
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> tags = new Dictionary<string, List<string>>();
            tags["a"] = new List<string>();
            tags["a"].Add("<current0>");
            tags["a"].Add("</current0>");
            tags["b"] = new List<string>();
            tags["b"].Add("<current1>");
            tags["b"].Add("</current1>");
            tags["c"] = new List<string>();
            tags["c"].Add("<current2>");
            tags["c"].Add("</current2>");
            tags["d"] = new List<string>();
            tags["d"].Add("<current3>");
            tags["d"].Add("</current3>");
            tags["e"] = new List<string>();
            tags["e"].Add("<current4>");
            tags["e"].Add("</current4>");
            tags["f"] = new List<string>();
            tags["f"].Add("<voltage0>");
            tags["f"].Add("</voltage0>");
            tags["g"] = new List<string>();
            tags["g"].Add("<voltage1>");
            tags["g"].Add("</voltage1>");
            tags["h"] = new List<string>();
            tags["h"].Add("<voltage2>");
            tags["h"].Add("</voltage2>");
            tags["i"] = new List<string>();
            tags["i"].Add("<voltage3>");
            tags["i"].Add("</voltage3>");
            tags["j"] = new List<string>();
            tags["j"].Add("<voltage4>");
            tags["j"].Add("</voltage4>");
            tags["k"] = new List<string>();
            tags["k"].Add("<pressure0>");
            tags["k"].Add("</pressure0>");
            tags["l"] = new List<string>();
            tags["l"].Add("<pressure1>");
            tags["l"].Add("</pressure1>");
            tags["m"] = new List<string>();
            tags["m"].Add("<pressure2>");
            tags["m"].Add("</pressure2>");
            tags["n"] = new List<string>();
            tags["n"].Add("<pressure3>");
            tags["n"].Add("</pressure3>");
            tags["o"] = new List<string>();
            tags["o"].Add("<pressure4>");
            tags["o"].Add("</pressure4>");
            tags["p"] = new List<string>();
            tags["p"].Add("<tempr0>");
            tags["p"].Add("</tempr0>");
            tags["q"] = new List<string>();
            tags["q"].Add("<tempr1>");
            tags["q"].Add("</tempr1>");
            tags["r"] = new List<string>();
            tags["r"].Add("<tempr2>");
            tags["r"].Add("</tempr2>");
            tags["s"] = new List<string>();
            tags["s"].Add("<tempr3>");
            tags["s"].Add("</tempr3>");
            tags["t"] = new List<string>();
            tags["t"].Add("<tempr4>");
            tags["t"].Add("</tempr4>");
            Console.WriteLine("Enter string");
            string input = Console.ReadLine();
            Console.WriteLine("Enter deviceID");
            string devid = Console.ReadLine();
            string date = Regex.Match(input, @"[0-9]{4}-(?<month>[0-9]{2})-[0-9]{2}[ ]*(?<hour>[0-9]{2}):[0-9]{2}:(?<secs>[0-9]{2})").ToString();
            string tohash = ((int.Parse(date.Substring(5,2)) + int.Parse(date.Substring(11,2)) + int.Parse(date.Substring(14,2)))*5).ToString() + devid.Reverse();
            string toc = CreateMD5(tohash).Substring(3, 8);
            Console.WriteLine("<dev_id>" + devid + "</dev_id>");
            Console.WriteLine("<date>" + date + "</date>");
            Console.WriteLine("<bagt>" + toc + "</bagt>");
            Console.WriteLine("<params>");
            foreach (Match item in Regex.Matches(input, @"(?<letter>[a-z]{1})(?<number>[0-9]+\.[0-9]+)"))
            {
                if (tags.ContainsKey(item.Groups["letter"].Value)) Console.WriteLine(tags[item.Groups["letter"].Value][0] + item.Groups["number"].Value + tags[item.Groups["letter"].Value][0]);
            }
            Console.WriteLine("</params>");
            Console.WriteLine("</akum_data>");

        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
