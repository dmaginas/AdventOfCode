from bisect import bisect_left
from tqdm import tqdm

def read_data(file_path):
    with open(file_path, 'r') as file:
        lines = file.read().strip().split('\n\n')
    seeds = list(map(int, lines[0].split()[1:]))  # Flatten the list into start/end pairs
    mappings = [[tuple(map(int, line.split())) for line in mapping.split('\n')[1:]] for mapping in lines[1:]]
    return seeds, mappings

# Find a converted value for a given number and mapping
def find_conversion(number, mapping):
    for start_dst, start_src, length in mapping:
        end_src = start_src + length
        if start_src <= number < end_src:
            return start_dst + (number - start_src)  # Convert the number using offset
    return number  # No conversion, return the number itself

# Find the lowest location number using all seeds and mappings
def find_lowest_location(seeds):
    global mappings
    lowest_location = float('inf')
    total_seeds = sum(seeds[1::2])  # Calculate total number of seeds to be processed
    processed_seeds = 0
    with tqdm(total=total_seeds) as pbar:
        for i in range(0, len(seeds), 2):
            for seed in range(seeds[i], seeds[i] + seeds[i + 1]):
                location = seed
                for mapping in mappings:
                    location = find_conversion(location, mapping)
                if location < lowest_location:
                    lowest_location = location
                processed_seeds += 1
                pbar.update(1)
    return lowest_location

# Main execution
seeds, mappings = read_data('../input/input_day5.txt')
result = find_lowest_location(seeds)
print(f"The lowest location number is {result}")