def find_destination(mapping, source_num):
    for dest_start, src_start, length in mapping:
        if src_start <= source_num < src_start + length:
            offset = source_num - src_start
            return dest_start + offset
    return source_num

def process_seed(seed, mappings):
    for mapping in mappings:
        seed = find_destination(mapping, seed)
    return seed

# Read the input file and parse the maps
with open('../input/input_day5.txt', 'r') as file:
    lines = file.readlines()

# Extract and parse seed ranges
initial_seeds = list(map(int, lines[0].strip().split(': ')[1].split()))
seed_ranges = [(initial_seeds[i], initial_seeds[i+1]) for i in range(0, len(initial_seeds), 2)]

# Generate all seed numbers
seeds = []
for start, length in seed_ranges:
    seeds.extend(range(start, start + length))

# Parse mappings
mappings = []
for line in lines[1:]:
    if "map:" in line:
        mappings.append([])
    else:
        parts = list(map(int, line.strip().split()))
        if parts:
            mappings[-1].append(tuple(parts))

# Find the lowest location number
lowest_location = min(process_seed(seed, mappings) for seed in seeds)

# Output the result
print(f"The lowest location number is {lowest_location}")