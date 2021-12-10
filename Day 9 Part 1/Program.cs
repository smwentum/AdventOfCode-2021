using System;
using System.IO;

namespace Day_9_Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 9 Part 1\real.txt");

            char[][] heatMap = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                heatMap[i] = lines[i].ToCharArray();
            }


            int answer = getSumOfRiskPointsRiskPoints(heatMap);

            Console.WriteLine(answer);

        }

        private static int getSumOfRiskPointsRiskPoints(char[][] heatMap)
        {
            int answer = 0;
            int temp = 0;

            // the points in the center of map
            for (int i = 1; i < heatMap.Length - 1; i++)
            {
                for (int j = 1; j < heatMap[0].Length - 1; j++)
                {
                    if (int.Parse(heatMap[i - 1][j].ToString()) > int.Parse(heatMap[i][j].ToString())
                        && int.Parse(heatMap[i + 1][j].ToString()) > int.Parse(heatMap[i][j].ToString())
                        && int.Parse(heatMap[i][j - 1].ToString()) > int.Parse(heatMap[i][j].ToString())
                        && int.Parse(heatMap[i][j + 1].ToString()) > int.Parse(heatMap[i][j].ToString())
                        )
                    {
                        temp = int.Parse(heatMap[i][j].ToString());
                        //Console.WriteLine(temp);
                        answer += temp + 1;
                    }
                }
            }

            //top
            for (int j = 1; j < heatMap[0].Length - 1; j++)
            {
                if (int.Parse(heatMap[0][j - 1].ToString()) > int.Parse(heatMap[0][j].ToString())
                    && int.Parse(heatMap[0][j + 1].ToString()) > int.Parse(heatMap[0][j].ToString())
                     && int.Parse(heatMap[1][j].ToString()) > int.Parse(heatMap[0][j].ToString())
                    )
                {
                    temp = int.Parse(heatMap[0][j].ToString());
                    //Console.WriteLine(temp);
                    answer += temp + 1;
                }
            }

            //bottom
            for (int j = 1; j < heatMap[0].Length - 1; j++)
            {
                if (int.Parse(heatMap[heatMap.Length - 1][j - 1].ToString()) > int.Parse(heatMap[heatMap.Length - 1][j].ToString())
                    && int.Parse(heatMap[heatMap.Length - 1][j + 1].ToString()) > int.Parse(heatMap[heatMap.Length - 1][j].ToString())
                     && int.Parse(heatMap[heatMap.Length - 2][j].ToString()) > int.Parse(heatMap[heatMap.Length - 1][j].ToString())
                    )
                {
                    temp = int.Parse(heatMap[heatMap.Length - 1][j].ToString());
                    //Console.WriteLine(temp);
                    answer += temp + 1;
                }
            }


            // left
             for (int i = 1; i < heatMap.Length - 1; i++)
             {

                if (int.Parse(heatMap[i - 1][0].ToString()) > int.Parse(heatMap[i][0].ToString())
                    && int.Parse(heatMap[i + 1][0].ToString()) > int.Parse(heatMap[i][0].ToString())
                    && int.Parse(heatMap[i][1].ToString()) > int.Parse(heatMap[i][0].ToString())
                    )
                {
                    temp = int.Parse(heatMap[i][0].ToString());
                    //Console.WriteLine(temp);
                    answer += temp + 1;
                }

             }


            // right
            for (int i = 1; i < heatMap.Length - 1; i++)
            {

                if (int.Parse(heatMap[i - 1][heatMap[0].Length-1].ToString()) > int.Parse(heatMap[i][heatMap[0].Length - 1].ToString())
                    && int.Parse(heatMap[i + 1][heatMap[0].Length - 1].ToString()) > int.Parse(heatMap[i][heatMap[0].Length - 1].ToString())
                    && int.Parse(heatMap[i][heatMap[0].Length - 2].ToString()) > int.Parse(heatMap[i][heatMap[0].Length - 1].ToString())
                    )
                {
                    temp = int.Parse(heatMap[i][heatMap[0].Length - 1].ToString());
                    //Console.WriteLine(temp);
                    answer += temp + 1;
                }

            }


            //the four weird points
            //top left 
            if (int.Parse(heatMap[0][1].ToString()) > int.Parse(heatMap[0][0].ToString())
                       && int.Parse(heatMap[1][0].ToString()) > int.Parse(heatMap[0][0].ToString())
                      
                       )
            {
                temp = int.Parse(heatMap[0][0].ToString());
                //Console.WriteLine(temp);
                answer += temp + 1;
            }

            //bottom left 
            if (int.Parse(heatMap[heatMap.Length - 1][1].ToString()) > int.Parse(heatMap[heatMap.Length - 1][0].ToString())
                       && int.Parse(heatMap[heatMap.Length - 2][0].ToString()) > int.Parse(heatMap[heatMap.Length - 1][0].ToString())

                       )
            {
                temp = int.Parse(heatMap[heatMap.Length-1][0].ToString());
                //Console.WriteLine(temp);
                answer += temp + 1;
            }


            //top right 
            if (int.Parse(heatMap[0][heatMap[0].Length-2].ToString()) > int.Parse(heatMap[0][heatMap[0].Length - 1].ToString())
                       && int.Parse(heatMap[1][heatMap[0].Length - 1].ToString()) > int.Parse(heatMap[0][heatMap[0].Length - 1].ToString())

                       )
            {
                temp = int.Parse(heatMap[0][heatMap[0].Length - 1].ToString());
                //Console.WriteLine(temp);
                answer += temp + 1;
            }

            //bottom right 
            if (int.Parse(heatMap[heatMap.Length - 1][heatMap[0].Length - 2].ToString()) > int.Parse(heatMap[heatMap.Length - 1][heatMap[0].Length - 1].ToString())
                       && int.Parse(heatMap[heatMap.Length - 2][heatMap[0].Length - 1].ToString()) > int.Parse(heatMap[heatMap.Length - 1][heatMap[0].Length - 1].ToString())

                       )
            {
                temp = int.Parse(heatMap[heatMap.Length - 1][heatMap[0].Length - 1].ToString());
                //Console.WriteLine(temp);
                answer += temp + 1;
            }



            return answer;
        }
    }
}
