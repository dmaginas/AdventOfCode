import itertools
import re

def find_first_and_last_occurrence(input_string):
    # Definiere die Muster für Ziffern und Wörter
    digit_pattern = re.compile(r'[1-9]')
    word_pattern = re.compile(r'one|two|three|four|five|six|seven|eight|nine')

    # Suche nach allen Übereinstimmungen im Eingabestring
    all_matches = re.findall(digit_pattern, input_string) + [word_to_digit(match) for match in re.findall(word_pattern, input_string)]

    if not all_matches:
        return None, None

    # Finde das erste und letzte Vorkommen
    first_occurrence = all_matches[0]
    last_occurrence = all_matches[-1]

    return first_occurrence, last_occurrence

def word_to_digit(word):
    # Übersetze Wort in Ziffer
    word_to_digit_mapping = {'one': '1', 'two': '2', 'three': '3', 'four': '4', 'five': '5', 'six': '6', 'seven': '7', 'eight': '8', 'nine': '9'}
    return word_to_digit_mapping.get(word, word)

def calculate_calibration_sum(file_path):
    with open(file_path, 'r') as file:
        lines = file.readlines()

    sum_of_calibrations = 0

    spelled_out_digits = {
        'one': '1', 'two': '2', 'three': '3', 'four': '4', 'five': '5',
        'six': '6', 'seven': '7', 'eight': '8', 'nine': '9'
    }

    for line in lines:
        first, last = find_first_and_last_occurrence(line)
        
        if first is None:
            first = ""

        if last is None:
            last = ""

        #if first is not None and last is not None:
        calibration_value = int(first + last)
        sum_of_calibrations += calibration_value

    return sum_of_calibrations

file_path = '../input/input_day1.txt'
result = calculate_calibration_sum(file_path)
print("Sum of calibration values:", result)
