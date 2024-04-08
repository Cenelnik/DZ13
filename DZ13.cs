using System.Collections.Generic;

namespace DZ13
{
    /// <summary>
    /// 13я домашка по OUTUS. Linq
    /// </summary>
    class DZ13
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>() { 2, 1, 5, 4, 3, 6, 9, 8, 7};
            foreach(var i in list.Top(20)) Console.WriteLine($"Next value: {i}");

            Func<Persone, int> Pred = (persone) => persone.Age;

            List<Persone> list2 = new List<Persone>();
            list2.Add(new Persone {Name = "AAAA", Age = 10 });
            list2.Add(new Persone { Name = "BBBB", Age = 12 });
            list2.Add(new Persone { Name = "CCCC", Age = 14 });
            list2.Add(new Persone { Name = "DDDD", Age = 50 });
            list2.Add(new Persone { Name = "EEEE", Age = 45 });
            list2.Add(new Persone { Name = "FFFF", Age = 47 });
            list2.Add(new Persone { Name = "JJJJ", Age = 96 });

            
            list2.Top(50, person => person.Age);

            foreach (var i in list2.Top(50, person => person.Age)) Console.WriteLine($"Next value: {i.Name}:{i.Age}");
        }


        public class Persone 
        {
            public string Name { get; set; } = "";
            public int Age { get; set; } = 0;
        }

    }
}