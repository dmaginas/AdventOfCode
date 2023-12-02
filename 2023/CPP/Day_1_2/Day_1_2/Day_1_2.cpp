// Day_1_2.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//

#include <iostream>
#include <fstream>
#include <string>
#include <map>

int calculateCalibrationSum(const std::string& filePath) {
    std::ifstream inputFile(filePath);
    if (!inputFile.is_open()) {
        std::cerr << "Error opening file: " << filePath << std::endl;
        return -1;
    }

    int sumOfCalibrations = 0;
    std::map<std::string, std::string> spelledOutDigits = {
        {"one", "1"}, {"two", "2"}, {"three", "3"}, {"four", "4"},
        {"five", "5"}, {"six", "6"}, {"seven", "7"}, {"eight", "8"}, {"nine", "9"}
    };

    std::string line;

    while (std::getline(inputFile, line)) {
        std::string currentDigit;
        std::string calibrationValue;

        for (char ch : line) {
            if (std::isalpha(ch)) {
                currentDigit += ch;
            }
            else if (std::isdigit(ch)) {
                if (!currentDigit.empty()) {
                    calibrationValue += spelledOutDigits[currentDigit];
                    currentDigit.clear();
                }
                calibrationValue += ch;
            }
        }

        if (!calibrationValue.empty()) {
            int value = std::stoi(calibrationValue);
            sumOfCalibrations += value;
        }
    }

    inputFile.close();
    return sumOfCalibrations;
}

int main() {
    std::string filePath = "d:\\Develop\\Python\\AdventOfCode\\2023\\input\\input_day1.txt";
    int result = calculateCalibrationSum(filePath);

    if (result != -1) {
        std::cout << "Sum of calibration values: " << result << std::endl;
    }

    return 0;
}


// Programm ausführen: STRG+F5 oder Menüeintrag "Debuggen" > "Starten ohne Debuggen starten"
// Programm debuggen: F5 oder "Debuggen" > Menü "Debuggen starten"

// Tipps für den Einstieg: 
//   1. Verwenden Sie das Projektmappen-Explorer-Fenster zum Hinzufügen/Verwalten von Dateien.
//   2. Verwenden Sie das Team Explorer-Fenster zum Herstellen einer Verbindung mit der Quellcodeverwaltung.
//   3. Verwenden Sie das Ausgabefenster, um die Buildausgabe und andere Nachrichten anzuzeigen.
//   4. Verwenden Sie das Fenster "Fehlerliste", um Fehler anzuzeigen.
//   5. Wechseln Sie zu "Projekt" > "Neues Element hinzufügen", um neue Codedateien zu erstellen, bzw. zu "Projekt" > "Vorhandenes Element hinzufügen", um dem Projekt vorhandene Codedateien hinzuzufügen.
//   6. Um dieses Projekt später erneut zu öffnen, wechseln Sie zu "Datei" > "Öffnen" > "Projekt", und wählen Sie die SLN-Datei aus.
