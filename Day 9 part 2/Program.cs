using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_9_part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 9 Part 2\real.txt");

            char[][] heatMap = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                heatMap[i] = lines[i].ToCharArray();
            }


            List<Tuple<int,int>> riskPoints = getListOfRiskPoints(heatMap);
            List<long> answer = new List<long>();
            foreach (Tuple<int,int> riskPoint in riskPoints)
            {
                answer.Add( getBasin(riskPoint,heatMap));
                Console.WriteLine(getBasin(riskPoint,heatMap));
            
            }
            answer.Sort();
            Console.WriteLine(answer[answer.Count - 1] * answer[answer.Count - 2] * answer[answer.Count - 3]);

            //Console.WriteLine(answer);

        }

        private static long getBasin(Tuple<int, int> riskPoint, char[][] heatMap)
        {
            List<Tuple<int, int>> vistedPoints = new List<Tuple<int, int>>();
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            long answer = 1;

            queue.Enqueue(riskPoint);
            Tuple<int, int> currentPoint;
            while (queue.Count > 0)
            { 
                currentPoint = queue.Dequeue();

                if (heatMap[currentPoint.Item1][currentPoint.Item2] != '9'&& !vistedPoints.Any(m => m.Item1 == currentPoint.Item1 && m.Item2 == currentPoint.Item2))
                {

                    if (currentPoint.Item1 > 0    && int.Parse(heatMap[currentPoint.Item1 - 1][currentPoint.Item2].ToString()) < 9   )
                    {
                        queue.Enqueue(new Tuple<int, int>(currentPoint.Item1 - 1, currentPoint.Item2));
                    }
                    if (currentPoint.Item1 < heatMap.Length - 1
                            && int.Parse(heatMap[currentPoint.Item1 + 1][currentPoint.Item2].ToString()) < 9
                         )
                    {
                        queue.Enqueue(new Tuple<int, int>(currentPoint.Item1 + 1, currentPoint.Item2));
                    }
                    if (currentPoint.Item2 > 0
                             && int.Parse(heatMap[currentPoint.Item1][currentPoint.Item2 - 1].ToString()) < 9
                        )
                    {
                        queue.Enqueue(new Tuple<int, int>(currentPoint.Item1, currentPoint.Item2 - 1));
                    }
                    if (currentPoint.Item2 < heatMap[0].Length - 1
                        && int.Parse(heatMap[currentPoint.Item1][currentPoint.Item2 + 1].ToString()) < 9
                       )
                    {
                        queue.Enqueue(new Tuple<int, int>(currentPoint.Item1, currentPoint.Item2 + 1));
                    }

                    
                        answer++;

                      
                    
                    vistedPoints.Add(currentPoint);
                }
            }

            return vistedPoints.Count;

           // return answer;
        }

        private static List<Tuple<int, int>> getListOfRiskPoints(char[][] heatMap)
        {
            List<Tuple<int,int>> answer = new List<Tuple<int,int>>();
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
                        answer.Add(new Tuple<int, int>(i, j));
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
                    //temp = int.Parse(heatMap[0][j].ToString());
                    //Console.WriteLine(temp);
                    answer.Add(new Tuple<int, int>(0, j));
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
                    answer.Add(new Tuple<int, int>(heatMap.Length - 1, j));
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
                    //temp = int.Parse(heatMap[i][0].ToString());
                    //Console.WriteLine(temp);
                    //answer += temp + 1;

                    answer.Add(new Tuple<int, int>(i, 0));
                }

            }


            // right
            for (int i = 1; i < heatMap.Length - 1; i++)
            {

                if (int.Parse(heatMap[i - 1][heatMap[0].Length - 1].ToString()) > int.Parse(heatMap[i][heatMap[0].Length - 1].ToString())
                    && int.Parse(heatMap[i + 1][heatMap[0].Length - 1].ToString()) > int.Parse(heatMap[i][heatMap[0].Length - 1].ToString())
                    && int.Parse(heatMap[i][heatMap[0].Length - 2].ToString()) > int.Parse(heatMap[i][heatMap[0].Length - 1].ToString())
                    )
                {
                    //temp = int.Parse(heatMap[i][heatMap[0].Length - 1].ToString());
                    //Console.WriteLine(temp);
                    //answer += temp + 1;
                    answer.Add(new Tuple<int, int>(i, heatMap[0].Length - 1));
                }

            }


            //the four weird points
            //top left 
            if (int.Parse(heatMap[0][1].ToString()) > int.Parse(heatMap[0][0].ToString())
                       && int.Parse(heatMap[1][0].ToString()) > int.Parse(heatMap[0][0].ToString())

                       )
            {
                //temp = int.Parse(heatMap[0][0].ToString());
                //Console.WriteLine(temp);
                answer.Add(new Tuple<int, int>(0, 0));
            }

            //bottom left 
            if (int.Parse(heatMap[heatMap.Length - 1][1].ToString()) > int.Parse(heatMap[heatMap.Length - 1][0].ToString())
                       && int.Parse(heatMap[heatMap.Length - 2][0].ToString()) > int.Parse(heatMap[heatMap.Length - 1][0].ToString())

                       )
            {
                //temp = int.Parse(heatMap[heatMap.Length - 1][0].ToString());
                //Console.WriteLine(temp);
                answer.Add(new Tuple<int, int>(0, 0));
            }


            //top right 
            if (int.Parse(heatMap[0][heatMap[0].Length - 2].ToString()) > int.Parse(heatMap[0][heatMap[0].Length - 1].ToString())
                       && int.Parse(heatMap[1][heatMap[0].Length - 1].ToString()) > int.Parse(heatMap[0][heatMap[0].Length - 1].ToString())

                       )
            {
                //temp = int.Parse(heatMap[0][heatMap[0].Length - 1].ToString());
                //Console.WriteLine(temp);
                //answer += temp + 1;
                answer.Add(new Tuple<int, int>(0, heatMap[0].Length - 1));
            }

            //bottom right 
            if (int.Parse(heatMap[heatMap.Length - 1][heatMap[0].Length - 2].ToString()) > int.Parse(heatMap[heatMap.Length - 1][heatMap[0].Length - 1].ToString())
                       && int.Parse(heatMap[heatMap.Length - 2][heatMap[0].Length - 1].ToString()) > int.Parse(heatMap[heatMap.Length - 1][heatMap[0].Length - 1].ToString())

                       )
            {
                //temp = int.Parse(heatMap[heatMap.Length - 1][heatMap[0].Length - 1].ToString());
                //Console.WriteLine(temp);
                answer.Add(new Tuple<int, int>(heatMap.Length - 1, heatMap[0].Length - 1));
            }



            return answer;
        }
    }
}
