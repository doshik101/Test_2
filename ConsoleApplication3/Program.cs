using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApplication3
{
    class Address
    {
        public string street { get; set; }
        public string house { get; set; }
        public string status { get; set; }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            StreamReader str = new StreamReader("input.csv");
            List<Address> addresses = new List<Address>();
            string S = str.ReadLine();
            while(S!=null)
            {
                string[] s1 = S.Split(',');
                addresses.Add(new Address() { street = s1[0], house=s1[1], status=s1[2]});
                S = str.ReadLine();

            }

            var addresses2 = from u in addresses where u.status == "да" select new{Street = u.street, House=u.house, Status=u.status};

            var addresses3 = from a in addresses2 orderby a.Street, a.House select a;

            StreamWriter sw = new StreamWriter("output.csv", false);
            foreach (var t in addresses3)
            {
                sw.WriteLine(t.Street + "," + t.House + "," + t.Status); 
            }
            
        }
    }
}