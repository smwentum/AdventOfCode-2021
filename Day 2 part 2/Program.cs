using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_2_Part_2 // Note: actual namespace depends on the project name.
{
    public class SonarSweepPt1
    {
        public static void Main(string[] args)
        {
            string[] depths = File.ReadAllLines("D:\\Documents\\random programming stuff\\Advent of code\\2021\\AdventOfCode\\Day 2 Part 2\\real.txt");

            int startX = 0;
            int startY = 0;
            int aim = 0;
            string direction;
            int pos;

            for (int i = 0; i < depths.Length; i++)
            {
                direction = depths[i].Split(' ')[0];
                pos = int.Parse(depths[i].Split(" ")[1]);
                switch (direction)
                {
                    case "forward":
                        startX += pos;
                        startY += aim * pos;
                        break;
                    case "down":
                        aim += pos;
                        //startY += pos;
                        break;
                    case "up":
                        aim -= pos;
                       // startY -= pos;
                        break;

                }
            }
            Console.WriteLine(startY * startX);
        }
    }
}