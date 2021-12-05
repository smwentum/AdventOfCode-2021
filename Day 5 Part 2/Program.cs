using Day_5_part_2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_5_Part_2 // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Line[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 5 part 2\real.txt").Select(m => new Line(m)).ToArray();

            int max = -1;
            int lineMax = 0;
            foreach (Line line in lines)
            {
                lineMax = Math.Max(Math.Max(line.x1, line.y1), Math.Max(line.x2, line.y2));
                if (max < lineMax)
                {
                    max = lineMax;
                }

            }

            //now create a grid
            int[,] grid = new int[max + 2, max + 2];

            //now mark all the ponits 
            foreach (Line line in lines.Where(m => m.isHorrizontal < 3))
            {
                markPointsInGrid(grid, line);
                //printGrid(grid);
                //Console.WriteLine();
            }
            int count = 0;
            foreach (int g in grid)
            {
                if (g > 1)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        private static void printGrid(int[,] grid)
        {
            string line = "";

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    line += grid[i, j].ToString() + " ";
                }
                Console.WriteLine(line);
                line = "";
            }
        }

        private static void markPointsInGrid(int[,] grid, Line line)
        {
            if (line.isHorrizontal == 0)
            {
                for (int i = line.x1; i <= line.x2; i++)
                {
                    grid[i, line.y1]++;
                }
            }

            else if (line.isHorrizontal == 1)
            {
                for (int i = line.y1; i <= line.y2; i++)
                {
                    grid[line.x1, i]++;
                }
            }
            else
            {
                for (int i = 0; i <= Math.Abs(line.x1 - line.x2); i++)
                {
                    if (line.x1 < line.x2 && line.y1 < line.y2)
                    {
                        grid[line.x1 + i, line.y1 + i]++;
                    }

                    else if (line.x1 < line.x2 && line.y1 > line.y2)
                    {
                        grid[line.x1 + i, line.y1 - i]++;
                    }

                    else if (line.x1 > line.x2 && line.y1 < line.y2)
                    {
                        grid[line.x1 - i, line.y1 + i]++;
                    }

                    else
                    {
                        grid[line.x1 - i, line.y1 - i]++;
                    }
                }
            }
        }
    }
}