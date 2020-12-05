using System;
using System.Collections.Generic;
using System.IO;

namespace DayFive
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = File.ReadAllText(@"input.txt");

            string[] boardingData = values.Split("\n");
            List<int> seatIds = new List<int>();
            foreach(string boarding in boardingData)
            {
                int minRow = 0, maxRow = 127, minCol = 0, maxCol = 7;
                char[] b = boarding.ToCharArray();

                foreach(char c in b)
                {
                    switch(c)
                    {
                        case 'F':
                            maxRow = (minRow + maxRow) / 2;
                            break;
                        case 'B':
                            minRow = (int)Math.Ceiling(((double)minRow + (double)maxRow) / 2.0);
                            break;
                        case 'R':
                            minCol = (int)Math.Ceiling(((double)minCol + (double)maxCol) / 2.0);
                            break;
                        case 'L':
                            maxCol = (minCol + maxCol) / 2;
                            break;
                    }
                }
                seatIds.Add(minRow * 8 + minCol);
            }
            seatIds.Sort();
            Console.WriteLine("Max seat id: " + seatIds[seatIds.Count - 1]);
            for(int i = 1; i < seatIds.Count - 1; i++)
            {
                if(seatIds[i - 1] == seatIds[i] - 2)
                {
                    Console.WriteLine("My seat is " + (seatIds[i] - 1));
                    break;
                }
            }
        }
    }
}
