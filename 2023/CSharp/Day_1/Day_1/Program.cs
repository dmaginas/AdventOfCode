using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "../../../../../input/input_day1.txt";
        int result = CalculateCalibrationSum(filePath);
        Console.WriteLine("Sum of calibration values: " + result);
    }

    static int CalculateCalibrationSum(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        int sumOfCalibrations = 0;

        foreach (string line in lines)
        {
            char[] digits = line.ToCharArray();
            int firstDigit = -1, lastDigit = -1;

            for (int i = 0; i < digits.Length; i++)
            {
                if (Char.IsDigit(digits[i]))
                {
                    if (firstDigit == -1)
                        firstDigit = int.Parse(digits[i].ToString());
                    lastDigit = int.Parse(digits[i].ToString());
                }
            }

            if (firstDigit != -1 && lastDigit != -1)
            {
                int calibrationValue = int.Parse(firstDigit.ToString() + lastDigit.ToString());
                sumOfCalibrations += calibrationValue;
            }
        }

        return sumOfCalibrations;
    }
}
