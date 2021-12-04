using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 3 Part 2\real.txt");
            bool[] validOxygenRating = new bool[lines.Length];
            bool[] validCO2Rating = new bool[lines.Length];
            Array.Fill(validOxygenRating, true);
            Array.Fill(validCO2Rating, true);
            int pos = 0;
            while (validOxygenRating.Count(m => m) > 1 && pos < lines[0].Length)
            {
                removeAnyLinesWithNotMostCommonBitInPosition(lines, validOxygenRating, pos);
                pos++;
            }

            pos = 0;
            while (validCO2Rating.Count(m => m) > 1 && pos < lines[0].Length)
            {
                removeAnyLinesWithMostCommonBitInPosition(lines, validCO2Rating, pos);
                pos++;
            }
            string oxygenRating = "";
            string co2Rating = "";
            for (int i = 0; i < validOxygenRating.Length; i++)
            {
                if (validOxygenRating[i])
                { 
                    oxygenRating = lines[i];
                    
                }
                if (validCO2Rating[i])
                { 
                    co2Rating= lines[i];
                }
            }
            //Console.WriteLine(oxygenRating);
            //Console.WriteLine(co2Rating);
            Console.WriteLine(Convert.ToInt32(oxygenRating,2) *Convert.ToInt32(co2Rating,2));
        }

        private static void removeAnyLinesWithNotMostCommonBitInPosition(string[] lines, bool[] validOxygenRating, int pos)
        {
            int count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (validOxygenRating[i] && lines[i][pos] == '1')
                {
                    count++;
                }
            }
            int totalCount = (int) Math.Ceiling(validOxygenRating.Count(m => m)/2.0) ;
            if (count >= totalCount)
            {
                //remove everything with a zero 
                for (int i = 0; i < lines.Length; i++)
                {
                    if (validOxygenRating[i] && lines[i][pos] == '0')
                    {
                        validOxygenRating[i] = false;
                    }
                }
            }
            else 
            {
                //remove everything with a 1
                for (int i = 0; i < lines.Length; i++)
                {
                    if (validOxygenRating[i] && lines[i][pos] == '1')
                    {
                        validOxygenRating[i] = false;
                    }
                }
            }
        }


        private static void removeAnyLinesWithMostCommonBitInPosition(string[] lines, bool[] validOxygenRating, int pos)
        {
            int count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (validOxygenRating[i] && lines[i][pos] == '1')
                {
                    count++;
                }
            }
            int totalCount = (int)Math.Ceiling(validOxygenRating.Count(m => m) / 2.0);
            if (count >= totalCount)
            {
                //remove everything with a zero 
                for (int i = 0; i < lines.Length; i++)
                {
                    if (validOxygenRating[i] && lines[i][pos] == '1')
                    {
                        validOxygenRating[i] = false;
                    }
                }
            }
            else
            {
                //remove everything with a 1
                for (int i = 0; i < lines.Length; i++)
                {
                    if (validOxygenRating[i] && lines[i][pos] == '0')
                    {
                        validOxygenRating[i] = false;
                    }
                }
            }
        }
    }
}