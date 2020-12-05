using System;
using System.Collections.Generic;
using System.IO;

namespace DayThree
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"slope.txt";
            List<char[]> myList = new List<char[]>();
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while((s = sr.ReadLine()) != null)
                {
                    myList.Add(s.ToCharArray());
                }
            }

            int width = 0;
            int depth = 0;
            int trees = 0;
            int totalTrees = 0;
            int factor = 1;

            foreach (char[] c in myList)
            {
                if (c[width] == '.')
                {
                }
                else
                {
                    trees++;
                }
                width += factor;
                width = width % c.Length;
            }
            totalTrees = trees;
            trees = 0;
            factor = 3;
            width = 0;
            foreach (char[] c in myList)
            {
                if(c[width] == '.')
                {
                }
                else
                {
                    trees++;
                }
                width += factor;
                width = width % c.Length;
            }
            totalTrees *= trees;
            factor = 5;
            trees = 0;
            width = 0;
            foreach (char[] c in myList)
            {
                if (c[width] == '.')
                {
                }
                else
                {
                    trees++;
                }
                width += factor;
                width = width % c.Length;
            }
            totalTrees *= trees;
            factor = 7;
            trees = 0;
            width = 0;
            foreach (char[] c in myList)
            {
                if (c[width] == '.')
                {
                }
                else
                {
                    trees++;
                }
                width += factor;
                width = width % c.Length;
            }

            totalTrees *= trees;
            factor = 1;
            trees = 0;
            width = 0;
            for (int i = 0; i < myList.Count; i += 2)
            {
                char[] c = myList[i];
                if (c[width] == '.')
                {

                }
                else
                {
                    trees++;
                }
                width += factor;
                width = width % c.Length;
            }

            totalTrees *= trees;

            Console.WriteLine(totalTrees);
        }
    }
}
