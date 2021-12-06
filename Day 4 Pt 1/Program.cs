using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_4_Pt_1 // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 4 Pt 1\real.txt");
            string gamma = "";
            string epsilon = "";
            int count = 0;
            for (int i = 0; i < lines[0].Length; i++)
            {
                count = 0;
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j][i] == '1')
                    {
                        count++;
                    }
                }
                if (count > lines.Length / 2)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }
            //Console.WriteLine(gamma);
            //Console.WriteLine(epsilon);
            int answer = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
            Console.WriteLine(answer);
        }
    }
}