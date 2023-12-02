def calculate_calibration_sum(file_path):
    with open(file_path, 'r') as file:
        lines = file.readlines()

    sum_of_calibrations = 0

    for line in lines:
        digits = [char for char in line if char.isdigit()]
        if len(digits) >= 1:
            calibration_value = int(digits[0] + digits[-1])
            sum_of_calibrations += calibration_value

    return sum_of_calibrations

file_path = '../input/input_day1.txt'
result = calculate_calibration_sum(file_path)
print("Sum of calibration values:", result)