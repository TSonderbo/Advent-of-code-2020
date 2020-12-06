using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = File.ReadAllText(@"input.txt");
            string[] customsData = values.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            var counts = customsData.Select(c =>
            {
                c = c.Replace("\n","");
                return c.ToCharArray().Distinct().Count();
            });

            var part1 = counts.Aggregate((a, b) => a + b);
            Console.WriteLine(part1);

            var countsTwo = customsData.Select(c =>
            {
                int noOfPeople = c.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Length;
                if(noOfPeople == 1)
                {
                    return c.Replace("\n", "").Length;
                }
                var uniqueAnswers = c.Replace("\n", "").ToCharArray().Distinct();
                int i = 0;
                foreach(char ch in uniqueAnswers)
                {
                    if(c.Count(x => (x == ch)) == noOfPeople)
                    {
                        i++;
                    }
                }
                return i;
            });

            var part2 = countsTwo.Aggregate((a, b) => a + b);
            Console.WriteLine(part2);
        }
    }
}
