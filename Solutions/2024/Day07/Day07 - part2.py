import time
import os
import operator
import itertools

def print_runtime(start_time):
    end_time = time.time()
    runtime = end_time - start_time
    print(f"Runtime: {runtime} seconds")

def initialize():
    start_time = time.time()
    year = 2024
    file_name = os.path.basename(__file__)
    print(f'{year} - {file_name}')
    return start_time

def read_and_store(filename):
    result = []
    with open(filename, 'r') as file:
        for line in file:
            x, values = line.split(':')
            x = int(x.strip())
            values = list(map(int, values.strip().split()))
            result.append((x, values))
    return result

def valid_combinations(numbers, target):
    if len(numbers) == 2:
        for op in operators.values():
            if op(numbers[0], numbers[1]) == target:
                return True
        return False

    # get all possible combinations
    for ops in itertools.product(operators.values(), repeat=len(numbers)-1):
        result = numbers[0]
        for i in range(len(ops)):
            result = ops[i](result, numbers[i+1])
        if result == target:
            return True
    return False

def find_valid_equations(data):
    total_calibration_result = 0
    for entry in data:
        target, numbers = entry
        if valid_combinations(numbers, target):
            total_calibration_result += target
    return total_calibration_result

def concat(a, b):
    return int(str(a) + str(b))

start_time = initialize()
result = 0

filename = "/workspaces/AdventOfCode/Solutions/2024/Day07/input.txt"
data = read_and_store(filename)

operators = {
    '+': operator.add,
    '*': operator.mul,
    '||': concat
}

result = find_valid_equations(data)

print(f'Result: {result }')
print_runtime(start_time)