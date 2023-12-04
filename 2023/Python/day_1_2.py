import itertools

def calculate_calibration_sum(file_path):
    with open(file_path, 'r') as file:
        lines = file.readlines()

    sum_of_calibrations = 0

    spelled_out_digits = {
        'one': '1', 'two': '2', 'three': '3', 'four': '4', 'five': '5',
        'six': '6', 'seven': '7', 'eight': '8', 'nine': '9'
    }

    for line in lines:
        words = list(itertools.chain.from_iterable(line))
        #words = line.split()
        first_digit = None
        last_digit = None

        for word in words:
            if word.isdigit():
                if first_digit is None:
                    first_digit = word
                last_digit = word
        
        matches = [x for x in spelled_out_digits if x in line]
        
        if len(matches) > 0:
            spelled_out = spelled_out_digits[matches[0].lower()]
            first_digit = spelled_out
        if len(matches) > 1:
            spelled_out = spelled_out_digits[matches[-1].lower()]        
            last_digit = spelled_out

        if first_digit is not None and last_digit is not None:
            calibration_value = int(first_digit + last_digit)
            sum_of_calibrations += calibration_value

    return sum_of_calibrations

file_path = '../input/input_day1.txt'
result = calculate_calibration_sum(file_path)
print("Sum of calibration values:", result)
