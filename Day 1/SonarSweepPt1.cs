using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode // Note: actual namespace depends on the project name.
{
    public class SonarSweepPt1
    {
        public static void Main(string[] args)
        {
            string[] depths = File.ReadAllLines("D:\\Documents\\random programming stuff\\Advent of code\\2021\\AdventOfCode\\Day 1\\test.txt");

            int start = int.Parse(depths[0]);
            int current; 
            int count = 0; 
            for (int i = 1; i < depths.Length;i++)
            { 
                current = int.Parse(depths[i]);
                if (start < current)
                { 
                    count++;
                }
                start = current;
            }
            Console.WriteLine(count);
        }
    }
}