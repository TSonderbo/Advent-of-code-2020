using System;
using System.Collections.Generic;
using System.IO;

namespace DayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"mytext.txt";

            var passwords = new List<string>();
            var letters = new List<char>();
            var min = new List<int>();
            var max = new List<int>();

            string[] temp;
            string[] tempNumbers;

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    temp = s.Split(' ');
                    tempNumbers = temp[0].Split('-');
                    min.Add(Int32.Parse(tempNumbers[0]));
                    max.Add(Int32.Parse(tempNumbers[1]));
                    letters.Add(temp[1].ToCharArray()[0]);
                    passwords.Add(temp[2]);
                }
            }

            if(passwords.Count != letters.Count || passwords.Count != min.Count || max.Count != passwords.Count)
            {
                Console.WriteLine("Read went wrong");
            }
            else
            {
                Console.WriteLine("Successful read!");

                int validPasswords = 0;

                for(int i = 0; i < passwords.Count; i++)
                {
                    var tempArray = passwords[i].ToCharArray();
                    int occurrences = 0;
                    foreach(char c in tempArray)
                    {
                        if (c == letters[i])
                            occurrences++;
                    }
                    if (occurrences >= min[i] && occurrences <= max[i])
                        validPasswords++;
                }

                Console.WriteLine("Total valid passwords: " + validPasswords);

                int validPasswordsTwo = 0;

                for(int i = 0; i < passwords.Count; i++)
                {
                    var tempArray = passwords[i].ToCharArray();
                    try
                    {
                        if ((tempArray[min[i] - 1] == letters[i] || tempArray[max[i] - 1] == letters[i])
                        && !(tempArray[min[i] - 1] == letters[i] && tempArray[max[i] - 1] == letters[i]))
                        {
                            validPasswordsTwo++;
                        }
                    }
                    catch(IndexOutOfRangeException)
                    {

                    }
                    
                }

                Console.WriteLine("Total valid passwords: " + validPasswordsTwo);
            }
        }
    }
}
