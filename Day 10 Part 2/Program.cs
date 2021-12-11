using System;
using System.Collections.Generic;
using System.IO;

namespace Day_10_Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 10 part 2\real.txt");

            List<long> answer = new List<long>();
            foreach (string line in lines)
            {
                //Console.WriteLine( getCorruptedLine(line));
                if(getCorruptedLine(line) == ' ')
                {
                    Console.WriteLine(getIncompleteLine(line));
                    Console.WriteLine(getScore(getIncompleteLine(line)));
                    answer.Add(getScore(getIncompleteLine(line))); 

                }
            }
            answer.Sort();
           Console.WriteLine(answer.Count);
           Console.WriteLine(answer[answer.Count / 2]);
        }
        
        private static long  getScore(string v)
        {
            long answer = 0;

            for (int i = 0; i <v.Length; i++)
            {
                answer *= 5;
                switch (v[i])
                {
                    case '(':
                        answer += 1;

                        break;
                    case '[':
                        answer += 2;

                        break;
                    case '{':
                        answer += 3;

                        break;
                    case '<':
                        answer += 4;
                        break; 
                }
            }

            return answer;
        }

        private static string getIncompleteLine(string line)
        {
            Stack<char> stack = new Stack<char>();
           

            //stack.Push(line[0]);
            char c = ' ';
            for (int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case '(':
                        stack.Push(line[i]);
                        break;
                    case '[':
                        stack.Push(line[i]);
                        break;
                    case '{':
                        stack.Push(line[i]);
                        break;
                    case '<':
                        stack.Push(line[i]);
                        break;
                    case ')':
                        c = stack.Pop();
                        if (c != '(')
                        {
                            Console.WriteLine("something is wrong");
                        }
                        
                        break;
                    case ']':
                        c = stack.Pop();
                        if (c != '[')
                        {
                            Console.WriteLine("something is wrong");
                        }
                        break;
                    case '}':
                        c = stack.Pop();
                        if (c != '{')
                        {
                            Console.WriteLine("something is wrong");
                        }
                        break;
                    case '>':
                        c = stack.Pop();
                        if (c != '<')
                        {
                            Console.WriteLine("something is wrong");
                        }
                        break;

                }

            }

            string answer = "";
            while (stack.Count > 0)
            {
                answer += stack.Pop();
                //switch (stack.Pop())
                //{ 
                //    case '(':
                //        stack.Push(line[i]);
                //        break;
                //    case '[':
                //        stack.Push(line[i]);
                //        break;
                //    case '{':
                //        stack.Push(line[i]);
                //        break;
                //    case '<':
                //        stack.Push(line[i]);
                //        break;
                //    //case ')':
                //    //    c = stack.Pop();

                //    //    break;
                //    //case ']':
                //    //    c = stack.Pop();

                //    //    break;
                //    //case '}':
                //    //    c = stack.Pop();

                //    //    break;
                //    //case '>':
                //    //    c = stack.Pop();

                //    //    break;

                //}
            }
            return answer; 
        }

        private static char getCorruptedLine(string line)
        {
            Stack<char> stack = new Stack<char>();

            stack.Push(line[0]);
            char c = ' ';
            for (int i = 1; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case '(':
                        stack.Push(line[i]);
                        break;
                    case '[':
                        stack.Push(line[i]);
                        break;
                    case '{':
                        stack.Push(line[i]);
                        break;
                    case '<':
                        stack.Push(line[i]);
                        break;
                    case ')':
                        c = stack.Pop();
                        if (c != '(')
                        {
                            return line[i];
                        }
                        break;
                    case ']':
                        c = stack.Pop();
                        if (c != '[')
                        {
                            return line[i];
                        }
                        break;
                    case '}':
                        c = stack.Pop();
                        if (c != '{')
                        {
                            return line[i];
                        }
                        break;
                    case '>':
                        c = stack.Pop();
                        if (c != '<')
                        {
                            return line[i];
                        }
                        break;

                }
            }


            return ' ';

        }
    }
}
