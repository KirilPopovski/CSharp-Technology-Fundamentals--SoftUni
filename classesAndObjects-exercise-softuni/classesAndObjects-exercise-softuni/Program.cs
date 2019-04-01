using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace classesAndObjects_exercise_softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for(int i=0;i<n;i++)
            {
                string[] vs = Console.ReadLine().Split('-');
                int flag = 0;
                foreach(var br in teams)
                {
                    if(br.Name == vs[1])
                    {
                        Console.WriteLine("Team {0} was already created!", vs[1]);
                        flag = 1;
                        break;
                    }
                }
                foreach (var br in teams)
                {
                    if (br.Creator == vs[0])
                    {
                        Console.WriteLine("{0} cannot create another team!", vs[1]);
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    Team tm = new Team();
                    tm.Creator = vs[0];
                    tm.Name = vs[1];
                    teams.Add(tm);
                    Console.WriteLine("Team {0} has been created by {1}!", vs[1], vs[0]);
                }
                else continue;
            }
            string assign = " ";
            while (assign != "end of assignment")
            {
                assign = Console.ReadLine();
                if (assign == "end of assignment") break;
                string[] data = Regex.Split(assign, "->");
                int flag = 0;
                foreach (var item in teams)
                {
                    if (item.Name == data[1]) { flag = 0; break; }
                    else flag++;
                }
                if (flag > 0)
                {
                    Console.WriteLine("Team {0} does not exist!",data[1]);
                    continue;
                }
                foreach(var item in teams)
                {
                    if(item.Members.Contains(data[0]) || item.Creator==data[0])
                    {
                        Console.WriteLine("Member {0} cannot join team {1}!", data[0], item.Name);
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1) continue;
                foreach (var item in teams)
                {
                    if (item.Name == data[1])
                    {
                        item.addMember(data[0]);
                        break;
                    }
                }
            }
            teams = teams.OrderBy(o => o.Name).ToList();
            foreach(var memb in teams)
            {
                if (memb.Count > 0) memb.printTeam();
            }
            Console.WriteLine("Teams to disband:");
            foreach(var mem in teams)
            {
                if (mem.Count == 0) Console.WriteLine(mem.Name);
            }
            Console.ReadKey();
        }
    }
    class Team
    {
        private string name;
        private string creator;
        private List<string> members;
        private int count;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Creator
        {
            get { return this.creator; }
            set { this.creator = value; }
        }
        public List<string> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }
        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }
        public Team()
        {
            this.members = new List<string>();
            count = 0;
        }
        public void addMember(string name)
        {
            this.members.Add(name);
            count++;
        }
        public void printTeam()
        {
            Console.WriteLine(this.name);
            Console.WriteLine("- {0}", this.creator);
            foreach(var item in this.members)
            {
                Console.WriteLine("-- {0}", item);
            }
        }
    }
}
