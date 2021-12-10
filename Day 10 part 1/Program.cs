using System;
using System.Collections.Generic;
using System.IO;

namespace Day_10_part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\Day 10 part 1\real.txt");

            long answer = 0;
            foreach (string line in lines)
            {
                //Console.WriteLine( getCorruptedLine(line));
                switch (getCorruptedLine(line))
                {
                    case ')':
                        answer += 3;
                        break;
                    case ']':
                        answer += 57;
                        break;
                    case '}':
                        answer += 1197;
                        break;
                    case '>':
                        answer += 25137;
                        break;
                    default:
                        break; 

                }
            }
            Console.WriteLine(answer);
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
