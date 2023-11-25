def calculate_score(strategy_guide):
    scores = {'A': 1, 'B': 2, 'C': 3, 'X': 1, 'Y': 2, 'Z': 3}

    total_score = 0

    with open(strategy_guide, 'r') as file:
        for line_number, line in enumerate(file, start=1):
            try:
                opponent, response = line.strip().split()
                if opponent not in scores or response not in scores:
                    raise ValueError(f"Invalid input at line {line_number}: {opponent}, {response}")
                
                opponent_score = scores[opponent]
                response_score = scores[response]

                # Calculate the round score
                round_score = response_score + (3 if response_score == opponent_score else 0)

                # Add the round score to the total score
                total_score += round_score
            except ValueError as e:
                print(f"Error: {e}")
                # Handle the error as needed

    return total_score

def main():
    input_file = "input_day2.txt"  # Replace with your file path
    total_score = calculate_score(input_file)
    print("The total score based on the strategy guide is:", total_score)

if __name__ == "__main__":
    main()
