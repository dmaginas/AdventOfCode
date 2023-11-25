def find_top_three_calories(elves_input):
    calories_per_elf = []
    current_calories = 0

    for line in elves_input:
        if line.strip():  # Check if the line is not empty
            current_calories += int(line)
        else:
            calories_per_elf.append(current_calories)
            current_calories = 0

    # Check for the last Elf's calories
    calories_per_elf.append(current_calories)

    # Sort the elves by calories in descending order
    sorted_calories = sorted(calories_per_elf, reverse=True)

    # Take the top three elves and calculate the total calories
    top_three_calories = sum(sorted_calories[:3])

    return top_three_calories

def main():
    file_path = "input_day1.txt" 
    with open(file_path, "r") as file:
        elves_input = file.readlines()

    result = find_top_three_calories(elves_input)
    print("The top three Elves are carrying a total of", result, "Calories.")

if __name__ == "__main__":
    main()
