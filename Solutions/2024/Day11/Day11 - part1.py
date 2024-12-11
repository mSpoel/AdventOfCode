from Helper import *

def blink(data):
    new_data = []
    for number in data:
        if number == '0':
            number = "1"
            new_data.append(number)
        elif len(number) % 2 == 0:
            mid = int(len(number)/2)
            number1 = number[:mid]
            number2 = str(int(number[mid:]))
            new_data.append(number1)
            new_data.append(number2)
        else:
            new_data.append(str(int(number)*2024))
    return new_data

start_time = initialize()
result = 0

with open("/workspaces/AdventOfCode/Solutions/2024/Day11/input.txt", "r") as file:
    matrix = [line.split() for line in file]
data = matrix[0]

print('Initial arrangement')
print(data)
for i in range(1, 26):
    data = blink(data)
    print(f'After {i} blinks: {len(data)}')
    print(data)

result = len(data)
print(f'Result: {result}')

print_runtime(start_time)