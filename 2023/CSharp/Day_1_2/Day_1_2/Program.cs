using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static Dictionary<string, string> spelledOutDigits = new Dictionary<string, string>
        {
            {"one", "1"}, {"two", "2"}, {"three", "3"}, {"four", "4"},
            {"five", "5"}, {"six", "6"}, {"seven", "7"}, {"eight", "8"}, {"nine", "9"}
        };

    static void Main()
    {
        string filePath = @"c:\workspace\AdventOfCode\AdventOfCode\2023\input\input_day1.txt";
        int result = CalculateCalibrationSum(filePath);

        if (result != -1)
        {
            Console.WriteLine("Sum of calibration values: " + result);
        }
    }

    static (string, int) FindFirst(MatchCollection input)
    {
        try
        {
            return (input[0].ToString(), 0);
        }
        catch (Exception)
        {
            return (null, -1);
        }
    }

    static (string, int) FindLast(MatchCollection input)
    {
        try
        {
            return (input[input.Count - 1].ToString(), input.Count - 1);
        }
        catch (Exception)
        {
            return (null, int.MaxValue);
        }
    }

    static int CountOccurrences(string input, string substring)
    {
        int count = 0;
        int index = input.IndexOf(substring);

        while (index != -1)
        {
            count++;
            index = input.IndexOf(substring, index + 1);
        }

        return count;
    }

    static int CalculateCalibrationSum(string filePath)
    {
       int sumOfCalibrations = 0;

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var digits = Regex.Matches(line, "\\d", RegexOptions.IgnoreCase);

                    List<string> words = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                    string pattern = string.Join("|", words.Select(w => Regex.Escape(w)));
                    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    var woerter = regex.Matches(line);

                    int idxFirstDigit = -1, idxLastDigit = -1, idxFirstWord = -1, idxLastWord = -1;
                    string firstDigit = string.Empty, lastDigit = string.Empty, firstWord = string.Empty, lastWord = string.Empty;
                    (firstDigit, idxFirstDigit) = FindFirst(digits);
                    (lastDigit, idxLastDigit) = FindLast(digits);

                    (firstWord, idxFirstWord) = FindFirst(woerter);
                    (lastWord, idxLastWord) = FindLast(woerter);
                    
                    var min = Math.Min(idxFirstDigit, idxFirstWord);
                    var max = Math.Max(idxLastDigit, idxLastWord);

                    string first = string.Empty;
                    string last = string.Empty;

                    if (idxFirstDigit != -1 && min == idxFirstDigit) first = firstDigit;
                    if (idxLastDigit != int.MaxValue && max == idxLastDigit) last = lastDigit;

                    if (idxFirstWord != -1 && min == idxFirstWord)
                    {
                        spelledOutDigits.TryGetValue(firstWord, out string strFirstWord);
                        if (!string.IsNullOrEmpty(strFirstWord))
                            first = strFirstWord;
                    }

                    if (idxLastWord != int.MaxValue && max == idxLastWord)
                    {
                        spelledOutDigits.TryGetValue(lastWord, out string strLastWord);
                        if (!string.IsNullOrEmpty(strLastWord))
                            last = strLastWord;
                    }

                    string calibrationValue = first + last;

                    Trace.WriteLine($"{line} ===> {calibrationValue}");
                    if (!string.IsNullOrEmpty(calibrationValue))
                    {
                        int value = int.Parse(calibrationValue);
                        sumOfCalibrations += value;
                    }
                }
            }

            return sumOfCalibrations;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in CalculateCalibrationSum: " + e.Message);
            return -1;
        }
    }
}

