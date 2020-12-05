using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"passports.txt";

            List<Passport> passports = new List<Passport>();

            using(StreamReader sr = File.OpenText(path))
            {
                string s;
                while((s = sr.ReadLine()) != null)
                {
                    while(sr.Peek() != 13 && !sr.EndOfStream)
                    {
                        s += " " + sr.ReadLine();
                    }

                    if(s.Length > 2)
                    {
                        Passport passport = new Passport();

                        string[] strings = s.Split(" ");

                        foreach (string str in strings)
                        {
                            string[] temp = str.Split(":");
                            switch(temp[0])
                            {
                                case "byr":
                                    passport.byr = temp[1];
                                    break;
                                case "iyr":
                                    passport.iyr = temp[1];
                                    break;
                                case "eyr":
                                    passport.eyr = temp[1];
                                    break;
                                case "hgt":
                                    passport.hgt = temp[1];
                                    break;
                                case "hcl":
                                    passport.hcl = temp[1];
                                    break;
                                case "ecl":
                                    passport.ecl = temp[1];
                                    break;
                                case "pid":
                                    passport.pid = temp[1];
                                    break;
                                case "cid":
                                    passport.cid = temp[1];
                                    break;
                                default:

                                    break;
                            }
                        }
                        passports.Add(passport);
                    }
                }
            }

            Console.WriteLine("Total passports: " + passports.Count);
            int i = 0;
            foreach(Passport pass in passports)
            {
                if(pass.isValid())
                {
                    i++;
                }
            }
            Console.WriteLine("Total valid passports: " + i);

            int j = 0;
            foreach (Passport pass in passports)
            {
                if (pass.isSuperValid())
                {
                    j++;
                }
            }
            Console.WriteLine("Total super valid passports: " + j);

        }
    }
}
