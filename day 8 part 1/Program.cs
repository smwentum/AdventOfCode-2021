using System;
using System.IO;

namespace day_8_part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //I dont thing i actaully understand the problem
            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\day 8 part 1\real.txt");

            int count = 0;
            string[] currentLine;
            foreach (string line in lines)
            {
                currentLine = line.Split(new char[] { '|' }, StringSplitOptions.TrimEntries)[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string code in currentLine)
                {
                    if (code.Length == 2
                        || code.Length == 3
                        || code.Length == 4
                        || code.Length == 7)
                    { 
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
