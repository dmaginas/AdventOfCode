using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

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

    static string FindFirstDigit(string input)
    {
        string currentDigit = "";
        string calibrationValue = "";

        foreach (char ch in input)
        {
            if (char.IsLetter(ch))
            {
                currentDigit += ch;
                try
                {
                    foreach (var key in spelledOutDigits.Keys)
                        if (currentDigit.Contains(key))
                            return spelledOutDigits[key];
                }
                catch (Exception)
                {
                    continue;
                }
            }
            else if (char.IsDigit(ch))
            {
                return ch.ToString();
            }
        }

        return calibrationValue;
    }

    static string FindLastDigit(string input)
    {
        string currentDigit = "";
        string calibrationValue = "";
        
        for (int i = input.Length - 1; i > 0; i--)
        {
            char ch = input[i];
            if (char.IsLetter(ch))
            {
                currentDigit = ch + currentDigit;
                try
                {
                    foreach (var key in spelledOutDigits.Keys)
                        if (currentDigit.Contains(key))
                                return spelledOutDigits[key];
                }
                catch (Exception)
                {
                    continue;
                }
            }
            else if (char.IsDigit(ch))
            {
                return ch.ToString();
            }
        }

        return calibrationValue;
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
                    string first = FindFirstDigit(line);
                    string last = FindLastDigit(line);

                    if (first == last)
                    {
                        // prüfen ob die Zahl nur einmal vorkommt
                        int countNumber = CountOccurrences(line, first);
                        var pair = spelledOutDigits.FirstOrDefault(x => x.Value == first);
                        int countWord = CountOccurrences(line, pair.Key);
                        int sum = countNumber + countWord;
                        if (sum == 1)
                            last = string.Empty;
                    }

                    //string currentDigit = "";
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
            Console.WriteLine("Error reading the file: " + e.Message);
            return -1;
        }
    }
}

