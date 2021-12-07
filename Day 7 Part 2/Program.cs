using System;
using System.IO;
using System.Linq;

namespace Day_7_Part_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long minFuleCost = long.MaxValue;

            string line = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 7 Part 2\test.txt")[0];

            int[] crabPositions = line.Split(',').Select(int.Parse).ToArray();

            for (int crabPosition = crabPositions.Min(); crabPosition <= crabPositions.Max(); crabPosition++)
            {
                minFuleCost = Math.Min(minFuleCost, getMinCostToMoveAllCrabs(crabPositions, crabPosition));
            }

            Console.WriteLine(minFuleCost);
        }

        private static long getMinCostToMoveAllCrabs(int[] crabPositions, int crabPosition)
        {
            int fuelCost = 0;
            int temp = 0;
            for (int i = 0; i < crabPositions.Length; i++)
            {
                temp = Math.Abs(crabPosition - crabPositions[i]);
                fuelCost += temp*(temp +1)/2;
            }

            return fuelCost;
        }
    }
}
