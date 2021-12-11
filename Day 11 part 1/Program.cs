using System;
using System.IO;

namespace Day_11_part_1
{
    internal class Program
    {
        static int[,] matrix;
        static int count;
        static void Main(string[] args)
        {
            count = 0;
            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 11 part 1\real.txt");

            matrix = new int[10, 10];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] = int.Parse(lines[i][j].ToString());
                }
            }
            printArray("starting one");
            for (int i = 1; i <= 100; i++)
            {
                AddOneToEveryValueInTheMatrix();
                //Console.WriteLine();
                ExplodeLight();
                //printArray($"Step {i}");
            }
            Console.WriteLine();
            Console.WriteLine(count);

        }

        private static void ExplodeLight()
        {
            if (AnyValueNeedsToBeExploed())
            {
                count++;
                //find the value
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > 9)
                        {
                            ExplodeLightHere(i, j);
                            ExplodeLight();
                        }

                    }
                }
             }
        }

        private static void ExplodeLightHere(int i, int j)
        {
            //top row
            if (i > 0)
            {
                if (matrix[i - 1, j] != 0)
                {
                    matrix[i - 1, j]++;
                }
            }
            if (i > 0 && j > 0)
            {
                if (matrix[i - 1, j - 1] != 0)
                {
                    matrix[i - 1, j - 1]++;
                }
            }
            if (i > 0 && j < matrix.GetLength(1)-1 )
            {
                if (matrix[i - 1, j + 1] != 0)
                {
                    matrix[i - 1, j + 1]++;
                }
            }

            //center 
            if (j > 0)
            {
                if (matrix[i, j-1] != 0)
                {
                    matrix[i , j-1]++;
                }
            }
            if ( j < matrix.GetLength(1) - 1)
            {
                if (matrix[i, j + 1] != 0)
                {
                    matrix[i , j + 1]++;
                }
            }

            //bottom 
            if (i < matrix.GetLength(0)-1)
            {
                if (matrix[i + 1, j] != 0)
                {
                    matrix[i + 1, j]++;
                }
            }
            if (i < matrix.GetLength(0) - 1 && j > 0)
            {
                if (matrix[i + 1, j - 1] != 0)
                {
                    matrix[i + 1, j - 1]++;
                }
            }
            if (i < matrix.GetLength(0) - 1 && j < matrix.GetLength(1) - 1)
            {
                if (matrix[i + 1, j + 1] != 0)
                {
                    matrix[i + 1, j + 1]++;
                }
            }

            matrix[i,j] = 0;
        }

        private static bool AnyValueNeedsToBeExploed()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 9)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static void AddOneToEveryValueInTheMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j]++;
                }
                
            }
        }

        private static void printArray(string message ="")
        {
            Console.WriteLine("\n"+message);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
