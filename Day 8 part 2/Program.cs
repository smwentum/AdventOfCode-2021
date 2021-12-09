using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_8_part_2
{
    internal class Program
    {
        private static List<Tuple<string, bool>> validConfiguaration;
        private static List<string> possiblePatterns;
        static void Main(string[] args)
        {
            
            string[] lines = File.ReadAllLines(@"D:\Documents\random programming stuff\Advent of code\2021\AdventOfCode\day 8 part 2\test1.txt");



            int count = 0;
            
            foreach (string line in lines)
            {
                List<string> currentLine = new List<string>();
                
                getAllConfiguations();
                
                currentLine.AddRange(line.Split(new char[] { '|' }, StringSplitOptions.TrimEntries)[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                currentLine.AddRange(line.Split(new char[] { '|' }, StringSplitOptions.TrimEntries)[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                count+= getValues(getValidCode(currentLine), currentLine) ;
                
            }

            Console.WriteLine(count);
        }

        private static int getValues(string correctConfig, List<string> currentLine)
        {
            int answer = 0;
            for (int i = 0; i < 4; i++)
            {
               answer+= (int) Math.Pow(10, i) * getIntFromConfigAndCode(correctConfig, currentLine[i + 10]);
            }
            return answer;
        }

        private static int getIntFromConfigAndCode(string correctConfig, string code)
        {

            if (code.Length == 2)
            {
                return 1;
            }
            if (code.Length == 3 )
            {
                return 7;
            }
            if (code.Length == 4)
            {
                return 4;
            }

            if (code.Length == 7)
            {
                return 8;
            }

            if (code.Length ==6 && getZeroPattern( code.ToUpper()) == $"{correctConfig[0]}{correctConfig[1]}{correctConfig[2]}.{correctConfig[3]}{correctConfig[4]}{correctConfig[5]}")
            {
                return 0;
            }
            if (code.Length == 6 && getSixPattern(code.ToUpper()) == $"{correctConfig[0]}{correctConfig[1]}.{correctConfig[2]}{correctConfig[3]}{correctConfig[4]}{correctConfig[5]}")
            {
                return 6;
            }
            if (code.Length == 6 && getNinePattern(code.ToUpper()) == $"{correctConfig[0]}{correctConfig[1]}{correctConfig[2]}{correctConfig[3]}.{correctConfig[4]}{correctConfig[5]}")
            {
                return 9;
            }

            if(code.Length == 5 && getTwoPattern( code.ToUpper()) == $"{correctConfig[0]}.{correctConfig[1]}{correctConfig[2]}{correctConfig[3]}.{correctConfig[4]}")
            {
                return 2; 
            }

            if (code.Length == 5 && getThreePattern( code.ToUpper()) == $"{correctConfig[0]}.{correctConfig[1]}{correctConfig[2]}.{correctConfig[3]}{correctConfig[4]}")
            {
                return 3;
            }
            string s = getFivePattern(code.ToUpper());
            string s1 = $"{correctConfig[0]}{correctConfig[1]}.{correctConfig[2]}.{correctConfig[3]}{correctConfig[4]}";
            possiblePatterns = new List<string>();
            permutePatternArray(code.ToUpper(), "");
            if (code.Length == 5 
                && possiblePatterns.Any(m=> getFivePattern( m) == $"{correctConfig[0]}{correctConfig[1]}.{correctConfig[2]}.{correctConfig[3]}{correctConfig[4]}"))
            {
                return 5;
            }
            Console.WriteLine("Wrong!");
            return -1;
        }

        private static string getValidCode(List<string> currentLine)
        {
            foreach (string code in currentLine)
            {
                //code = code.ToUpper();
                if (code.Length == 2)
                {
                    generateAllTwoPatterns(code.ToUpper());
                    //removeConfigurationsThatDontMatchAnyOfPatterns(new string[] { generateTwoPattern(code.ToUpper()) });
                }
                else if (code.Length == 3)
                {
                    generateAllThreePatterns(code.ToUpper());
                    //removeConfigurationsThatDontMatchAnyOfPatterns(new string[] { generateThreePattern(code.ToUpper()) });
                }
                else if (code.Length == 4)
                {
                    generateAllFourPatterns(code.ToUpper());
                    //removeConfigurationsThatDontMatchAnyOfPatterns(new string[] { generateFourPattern(code.ToUpper()) });
                }
                else if (code.Length == 7)
                {
                    generateAllSevenPatterns(code.ToUpper());
                    //removeConfigurationsThatDontMatchAnyOfPatterns(new string[] { generateSevenPattern(code.ToUpper()) });
                }
                else if (code.Length == 6)
                {
                    generateAllSixPatterns(code.ToUpper());
                }
            }
            foreach (Tuple<string,bool> s in validConfiguaration)
            {
                Console.WriteLine(s.Item1);
            }
            return validConfiguaration[0].Item1;
        }



        #region two patterns

        private static void generateAllTwoPatterns(string ab)
        {
            possiblePatterns = new List<string>();
            permutePatternArray(ab, "");
            string[] answer = new string[possiblePatterns.Count];

            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = generateTwoPattern(possiblePatterns[i]);
            }
            removeConfigurationsThatDontMatchAnyOfPatterns(answer);
        }

        private static string generateTwoPattern(string v)
        {
            return $"..{v[0]}..{v[1]}.";
        }
        #endregion

        #region three patterns

        private static void generateAllThreePatterns(string ab)
        {
            possiblePatterns = new List<string>();
            permutePatternArray(ab, "");
            string[] answer = new string[possiblePatterns.Count];

            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = generateThreePattern(possiblePatterns[i]);
            }
            removeConfigurationsThatDontMatchAnyOfPatterns(answer);
        }

        private static string generateThreePattern(string v)
        {
            return $"{v[0]}.{v[1]}..{v[2]}.";
        }
        #endregion


        #region four patterns

        private static void generateAllFourPatterns(string ab)
        {
            possiblePatterns = new List<string>();
            permutePatternArray(ab, "");
            string[] answer = new string[possiblePatterns.Count];

            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = generateFourPattern(possiblePatterns[i]);
            }
            removeConfigurationsThatDontMatchAnyOfPatterns(answer);
        }

        private static string generateFourPattern(string v)
        {
            return $".{v[0]}{v[1]}{v[2]}.{v[3]}.";
        }
        #endregion


        #region six patterns

        private static void generateAllSixPatterns(string ab)
        {
            possiblePatterns = new List<string>();
            permutePatternArray(ab, "");
            List<string> answer = new List<string>();

            for (int i = 0; i < possiblePatterns.Count; i++)
            {
                answer.AddRange(generateSixPattern(possiblePatterns[i]));
            }
            removeConfigurationsThatDontMatchAnyOfPatterns(answer.ToArray());
        }

        private static List<string> generateSixPattern(string v)
        {

            return new List<string> { getZeroPattern(v),
                                      getSixPattern(v),
                                      getNinePattern(v)};
        }
        #endregion

        #region seven patterns

        private static void generateAllSevenPatterns(string ab)
        {
            possiblePatterns = new List<string>();
            permutePatternArray(ab, "");
            string[] answer = new string[possiblePatterns.Count];

            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = generateSevenPattern(possiblePatterns[i]);
            }
            removeConfigurationsThatDontMatchAnyOfPatterns(answer);
        }

        private static string generateSevenPattern(string v)
        {
            return $"{v[0]}{v[1]}{v[2]}{v[3]}{v[4]}{v[5]}{v[6]}";
        }
        #endregion

        #region other patterns

        private static string getZeroPattern(string v)
        {
            return $"{v[0]}{v[1]}{v[2]}.{v[3]}{v[4]}{v[5]}";
        }

        private static string getSixPattern(string v)
        {
            return $"{v[0]}{v[1]}.{v[2]}{v[3]}{v[4]}{v[5]}";
        }

        private static string getNinePattern(string v)
        {
           return $"{v[0]}{v[1]}{v[2]}{v[3]}.{v[4]}{v[5]}";
        }

        private static string getTwoPattern(string correctConfig)
        {

            return $"{correctConfig[0]}.{correctConfig[1]}{correctConfig[2]}{correctConfig[3]}.{correctConfig[4]}";
        }

        private static string getThreePattern(string correctConfig)
        {

            return $"{correctConfig[0]}.{correctConfig[1]}{correctConfig[2]}.{correctConfig[3]}{correctConfig[4]}";
        }

        private static string getFivePattern(string correctConfig)
        {

            return $"{correctConfig[0]}{correctConfig[1]}.{correctConfig[2]}.{correctConfig[3]}{correctConfig[4]}";
        }
        #endregion

        private static void getAllConfiguations()
        {
            validConfiguaration = new List<Tuple<string, bool>>();
            permute("ABCDEFG", "");
        }

        private static void removeConfigurationsThatDontMatchAnyOfPatterns(string[] patterns)
        {
            for (int i = 0; i < validConfiguaration.Count; i++)
            {
                if (!patterns.Any(m => isValidPattern(m, validConfiguaration[i].Item1)))
                {
                    validConfiguaration.RemoveAt(i);
                    i--;
                }
            }
        }

        private static bool isValidPattern(string m, string item1)
        {
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] != '.' && m[i] != item1[i])
                {
                    return false;
                }
            }
            return true; 

        }

        static void permute(String s, String answer)
        {
            if (s.Length == 0)
            {
                validConfiguaration.Add(new Tuple<string,bool>(answer,true));
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                string left_substr = s.Substring(0, i);
                string right_substr = s.Substring(i + 1);
                string rest = left_substr + right_substr;
                permute(rest, answer + ch);
            }
        }


        static void permutePatternArray(String s, String answer)
        {
            if (s.Length == 0)
            {
                possiblePatterns.Add(answer);
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                string left_substr = s.Substring(0, i);
                string right_substr = s.Substring(i + 1);
                string rest = left_substr + right_substr;
                permutePatternArray(rest, answer + ch);
            }
        }
    }
}
