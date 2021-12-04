using Day_4_Part_1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 4 Part 1\real.txt");

            //the first line is the calls
            List<int> calls = lines[0].Split(',').Select(int.Parse).ToList();

            List<string> bingoBoard = new List<string>();
            List<Bingo[,]> bingoBoards = new List<Bingo[,]>();
            //create all the boards
            for(int i = 1; i < lines.Length;i++)
            {
                if (!string.IsNullOrWhiteSpace(lines[i]))
                { 
                    bingoBoard.Add(lines[i]);
                }
                if (bingoBoard.Count == 5)
                {
                    //create a board
                    bingoBoards.Add(createBingBoardFromLines(bingoBoard));
                    bingoBoard = new List<string>();
                }

            }

            int product = -1;
            int sumOfunmarkedNumbers = 0;
            for (int i = 0; i < calls.Count; i++)
            { 
                int call = calls[i];
                for (int j = 0; j < bingoBoards.Count; j++)
                {
                     markCall(bingoBoards[j], call);
                    product = isWinningBOard(bingoBoards[j]);
                    
                    if ( product >= 0)
                    {
                        sumOfunmarkedNumbers = getSumOfUnmarkedNumbers(bingoBoards[j]);
                        Console.WriteLine(sumOfunmarkedNumbers*call);
                        return;
                    }
                }
            }
        }

        private static int getSumOfUnmarkedNumbers(Bingo[,] bingos)
        {
            int sum = 0;
            foreach (Bingo bingo in bingos)
            {
                if (!bingo.marked)
                {
                    sum += bingo.square;
                }
            }
            return sum;
        }

        private static int isWinningBOard(Bingo[,] bingos)
        {
            int answer = 1;
            for (int i = 0; i < bingos.GetLength(0); i++)
            {
                answer = 1;
                for (int j = 0; j < bingos.GetLength(1); j++)
                {
                    if (!bingos[i, j].marked)
                    {
                        answer = -1;
                        break;
                    }
                    else
                    { 
                        answer+= bingos[i, j].square;
                    }
                }
                if (answer >= 0)
                {
                    return answer; 
                }
            }

            answer = 1;
            for (int i = 0; i < bingos.GetLength(0); i++)
            {
                answer = 1;
                for (int j = 0; j < bingos.GetLength(1); j++)
                {
                    if (!bingos[j, i].marked)
                    {
                        answer = -1;
                        break;
                    }
                    else
                    {
                        answer *= bingos[j, i].square;
                    }
                }
                if (answer >= 0)
                {
                    return answer;
                }
            }
            return -1;
        }

        private static void markCall(Bingo[,] bingos, int call)
        {
            for (int i = 0; i < bingos.GetLength(0); i++)
            {
                for (int j = 0; j < bingos.GetLength(1); j++)
                {
                    if (bingos[i, j].square == call)
                    {
                        bingos[i, j].marked = true;
                        return;
                    }
                }
            }
        }

        private static Bingo[,] createBingBoardFromLines(List<string> listOfLines)
        {
            Bingo[,] bingoBoard = new Bingo[5, 5];
            string line;
            for (int i = 0; i <5; i++)
            {
                line = listOfLines[i];
                for (int j = 0; j < 5; j++)
                {
                    bingoBoard[i, j] = new Bingo( int.Parse(line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries )[j]));
                }
            }
            return bingoBoard;

        }
    }
}