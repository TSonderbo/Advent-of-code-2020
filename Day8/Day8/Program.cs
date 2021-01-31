using System;
using System.Collections.Generic;
using System.IO;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = File.ReadAllText(@"input.txt");
            string[] instructions = values.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            int index = 0;
            int acc = 0;
            List<int> instructionIndexes = new List<int>();
            /* Part one
            for(;index < instructions.Length;)
            {
                if(instructionIndexes.Contains(index))
                {
                    Console.WriteLine("Duplicate index was: " + index);
                    break;
                }
                instructionIndexes.Add(index);

                switch (instructions[index][0])
                {
                    case 'a':
                        int accValue = Int32.Parse(instructions[index].Substring(5));
                        if(instructions[index][4] == '-')
                        {
                            acc -= accValue;
                            index++;
                            break;
                        }
                        if(instructions[index][4] == '+')
                        {
                            acc += accValue;
                            index++;
                            break;
                        }
                        Console.WriteLine("Failed to interpret acc");
                        break;
                    case 'j':
                        int jmpValue = Int32.Parse(instructions[index].Substring(5));
                        if (instructions[index][4] == '-')
                        {
                            index -= jmpValue;
                            break;
                        }
                        if (instructions[index][4] == '+')
                        {
                            index += jmpValue;
                            break;
                        }
                        Console.WriteLine("Failed to interpret jmp");
                        break;
                    case 'n':
                        index++;
                        break;
                }
            }
            Console.WriteLine("Loop count: " + instructionIndexes.Count);
            Console.WriteLine("Accumulator value: " + acc);

            */

            //Part two
            bool instructionChanged = false;
            List<int> nopIndexes = new List<int>();
            List<int> jmpIndexes = new List<int>();
            while(index < instructions.Length)
            {
                if (instructionIndexes.Contains(index))
                {
                    acc = 0;
                    index = 0;
                    instructionChanged = false;
                    instructionIndexes.Clear();
                    Console.WriteLine("Resetting.. Size of jmp indexes: " + jmpIndexes.Count);
                }
                instructionIndexes.Add(index);

                switch (instructions[index][0])
                {
                    case 'a':
                        int accValue = Int32.Parse(instructions[index].Substring(5));
                        if (instructions[index][4] == '-')
                        {
                            acc -= accValue;
                            index++;
                            break;
                        }
                        if (instructions[index][4] == '+')
                        {
                            acc += accValue;
                            index++;
                            break;
                        }
                        Console.WriteLine("Failed to interpret acc");
                        break;
                    case 'j':
                        if(!jmpIndexes.Contains(index) && !instructionChanged)
                        {
                            instructionChanged = true;
                            jmpIndexes.Add(index);
                            index++;
                            break;
                        }
                        int jmpValue = Int32.Parse(instructions[index].Substring(5));
                        if (instructions[index][4] == '-')
                        {
                            index -= jmpValue;
                            break;
                        }
                        if (instructions[index][4] == '+')
                        {
                            index += jmpValue;
                            break;
                        }
                        Console.WriteLine("Failed to interpret jmp");
                        break;
                    case 'n':
                        /*
                        if(!nopIndexes.Contains(index) && !instructionChanged)
                        {
                            nopIndexes.Add(index);
                            instructionChanged = true;
                            int nopValue = Int32.Parse(instructions[index].Substring(5));
                            if (instructions[index][4] == '-')
                            {
                                index -= nopValue;
                                break;
                            }
                            if (instructions[index][4] == '+')
                            {
                                index += nopValue;
                                break;
                            }
                        }
                        else
                        {
                            index++;
                        }
                        break;
                        */
                        index++;
                        break;
                }
            }
            Console.WriteLine("Loop count: " + instructionIndexes.Count);
            Console.WriteLine("Accumulator value: " + acc);
        }
    }
}
