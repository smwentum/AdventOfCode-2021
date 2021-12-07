using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_6_part_2 // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static long[,] memo;
        public static void Main(string[] args)
        {
            //i might just do a strignt recursion and the flip it to dp? 

            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 6 Part 2\real.txt");
            Dictionary<int, int> countOfStartingFish = new Dictionary<int, int>();

            foreach (string fishStartTime in lines[0].Split(','))
            {
                if (!countOfStartingFish.ContainsKey(int.Parse(fishStartTime)))
                {
                    countOfStartingFish.Add(int.Parse(fishStartTime), 1);
                }
                else
                {
                    countOfStartingFish[int.Parse(fishStartTime)]++;
                }
            }
            int numberOfdays = 256;
            memo = new long[9, numberOfdays+1];
            long answer = 0;
            foreach (KeyValuePair<int, int> keyValuePair in countOfStartingFish)
            {
                answer += dp(keyValuePair.Key, numberOfdays) * keyValuePair.Value;
            }
            Console.WriteLine(answer);
        }

        private static long dp(int timeUntilReproducing, int timeLeft)
        {
            if (timeUntilReproducing >= timeLeft)
            {
                return 1;
            }
            if (memo[timeUntilReproducing, timeLeft] == 0)
            {
                memo[timeUntilReproducing, timeLeft] = dp(6, timeLeft - timeUntilReproducing - 1) + dp(8, timeLeft - timeUntilReproducing - 1);
            }
            return memo[timeUntilReproducing, timeLeft];
        }
    }
}