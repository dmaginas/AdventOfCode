def find_max_calories(elves_input):
    max_calories = 0
    current_calories = 0

    for line in elves_input:
        if line.strip():  # Check if the line is not empty
            current_calories += int(line)
        else:
            max_calories = max(max_calories, current_calories)
            current_calories = 0

    # Check for the last Elf's calories
    max_calories = max(max_calories, current_calories)

    return max_calories

def main():
    file_path = "input_day1.txt"
    with open(file_path, "r") as file:
        elves_input = file.readlines()

    result = find_max_calories(elves_input)
    print("The Elf carrying the most Calories is carrying a total of", result, "Calories.")

if __name__ == "__main__":
    main()
