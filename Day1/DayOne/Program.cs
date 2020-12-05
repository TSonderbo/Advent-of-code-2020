using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace DayOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"\numbers.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Couldn't find file");
            }

            var list = new List<int>();

            using (StreamReader sr = File.OpenText(path))
            {
                int i;
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    i = Int32.Parse(s);
                    list.Add(i);
                }
            }

            int loopCount = 0;

            //Two entries that add to 2020
            for(int i = 0; i < list.Count; i++)
            {
                for(int j = i + 1; j < list.Count; j++)
                {
                    if(list[i] + list[j] == 2020)
                    {
                        Console.WriteLine(list[i] + " + " + list[j] + " = " + (list[i] + list[j]));
                        Console.WriteLine(list[i] + " * " + list[j] + " = " + (list[i] * list[j]));
                    }
                    loopCount++;
                }
            }

            //Three entris that add to 2020
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    for(int k = j + 1; k < list.Count; k++)
                    {
                        if (list[i] + list[j] + list[k] == 2020)
                        {
                            Console.WriteLine(list[i] + " + " + list[j] + " + " + list[k] + " = " + (list[i] + list[j] + list[k]));
                            Console.WriteLine(list[i] + " * " + list[j] + " * " + list[k] + " = " + (list[i] * list[j] * list[k]));
                        }
                    }
                }
            }
        }
    }
}
