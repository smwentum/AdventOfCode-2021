using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_1_Part_2 // Note: actual namespace depends on the project name.
{
    public class SonarSweepPt1
    {
        public static void Main(string[] args)
        {
            string[] depths = File.ReadAllLines("D:\\Documents\\random programming stuff\\Advent of code\\2021\\AdventOfCode\\Day 1 Part 2\\test.txt");

            int start = int.Parse(depths[0]) + int.Parse(depths[1]) + int.Parse(depths[2]);
            int current = int.Parse(depths[3]) + int.Parse(depths[1]) + int.Parse(depths[2]);
            int count = 0;
            for (int i = 1; i < depths.Length - 3; i++)
            {
                if (start < current)
                {
                    //Console.WriteLine(i);
                    count++;
                }
                start = current;
                current -= int.Parse(depths[i]);
                current += int.Parse(depths[i + 3]);
            }
            if (start < current)
            {
                //Console.WriteLine(i);
                count++;
            }
            Console.WriteLine(count);
        }
    }
}