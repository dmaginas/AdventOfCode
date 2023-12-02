using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = @"d:\Develop\Python\AdventOfCode\2023\input\input_day1.txt";
        int result = CalculateCalibrationSum(filePath);

        if (result != -1)
        {
            Console.WriteLine("Sum of calibration values: " + result);
        }
    }

    static int CalculateCalibrationSum(string filePath)
    {
        Dictionary<string, string> spelledOutDigits = new Dictionary<string, string>
        {
            {"one", "1"}, {"two", "2"}, {"three", "3"}, {"four", "4"},
            {"five", "5"}, {"six", "6"}, {"seven", "7"}, {"eight", "8"}, {"nine", "9"}
        };

        int sumOfCalibrations = 0;

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string currentDigit = "";
                    string calibrationValue = "";

                    foreach (char ch in line)
                    {
                        if (char.IsLetter(ch))
                        {
                            currentDigit += ch;
                        }
                        else if (char.IsDigit(ch))
                        {
                            if (spelledOutDigits.TryGetValue(currentDigit, out string mappedDigit))
                            {
                                calibrationValue += mappedDigit;
                            }
                            else
                            {
                                // Handle the case where currentDigit is not found in spelledOutDigits
                                Console.WriteLine("Warning: Unrecognized spelled-out digit: " + currentDigit);
                            }

                            currentDigit = "";
                            calibrationValue += ch;
                        }
                    }

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

