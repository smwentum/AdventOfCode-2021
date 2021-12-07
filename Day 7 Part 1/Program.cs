using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_7_Part_1 // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int minFuleCost = int.MaxValue;

            string line = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 7 Part 1\real.txt")[0];
            
            int[] crabPositions = line.Split(',').Select(int.Parse).ToArray();

            foreach (int crabPosition in crabPositions.Distinct())
            {
                minFuleCost = Math.Min(minFuleCost, getMinCostToMoveAllCrabs(crabPositions, crabPosition));
            }

            Console.WriteLine(minFuleCost);
        }

        private static int getMinCostToMoveAllCrabs(int[] crabPositions, int crabPosition)
        {
            int fuelCost = 0;

            for (int i = 0; i < crabPositions.Length; i++)
            {
                fuelCost += Math.Abs(crabPosition - crabPositions[i]);
            }

            return fuelCost;
        }
    }
}