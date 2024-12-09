from Helper import *

start_time = initialize()

with open("/workspaces/AdventOfCode/Solutions/2024/Day09/example.txt", "r") as file:
    data = [list(line) for line in file]

input = data[0]
print(input)

result = 0
currentDigit = 0
count_index = 0
backwards_count_index = 0
backwards_index = len(input)+1
digitsToMove = 0

for index in range(0, len(input)):
    if index > backwards_index:
        break
    numberOfDigits = int(input[index])
    if index % 2 == 1:
        while(numberOfDigits > 0 ):
            if digitsToMove == 0:
                backwards_index -= 2
                digitsToMove = int(input[backwards_index])
            
            digitsToMove -= 1
            number = int(backwards_index / 2)
            print(number)
            result += number * count_index
            count_index += 1
            numberOfDigits -= 1
            backwards_count_index += 1
            if (backwards_count_index == count_index):
                break
            # figure out a way to break at the right moment, now we stay to long in the six
    else:
        for index_digits in (range(0, numberOfDigits)):
            result += currentDigit * count_index
            count_index += 1
            print(currentDigit)
        currentDigit += 1
    
print(f'Resuit: {result}')

print_runtime(start_time)