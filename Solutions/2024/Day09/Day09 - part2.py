from Helper import *

start_time = initialize()
result = 0

with open("/workspaces/AdventOfCode/Solutions/2024/Day09/input.txt", "r") as file:
    data = [list(line) for line in file]

input = data[0]
print(input)

count_index = 0
current_digit= 0

for index in range(0, len(input)):
    number_of_digits = int(input[index])
    backwards_index = len(input)-1
    if index % 2 == 1:
        backup_digits = number_of_digits
        while number_of_digits > 0:
            backwards_number = int(input[backwards_index])
            while backwards_index > index and (backwards_number > number_of_digits or backwards_number < 0):
                backwards_index -= 2
                backwards_number = int(input[backwards_index])

            if backwards_index > index:
                calc_number = int(backwards_index / 2)
                input[backwards_index] = -backwards_number

                for i in range(0, backwards_number):
                    result += count_index * calc_number
                    print(f'{calc_number} * {count_index} = {calc_number * count_index} -> result: {result}')
                    count_index += 1
                    number_of_digits -= 1
            else:
                rangenumber = number_of_digits
                for i in range(0, rangenumber):
                    print('.')
                    count_index += 1
                    number_of_digits -= 1

    else:
        if number_of_digits < 0:
            number_of_digits = abs(number_of_digits)
            backup_digits = number_of_digits
            while number_of_digits > 0:
                backwards_number = int(input[backwards_index])
                while backwards_index > index and (backwards_number > number_of_digits or backwards_number < 0):
                    backwards_index -= 2
                    backwards_number = int(input[backwards_index])

                if backwards_index > index:
                    calc_number = int(backwards_index / 2)
                    input[backwards_index] = -backwards_number
                    for i in range(0, backwards_number):
                        result += count_index * calc_number
                        print(f'{calc_number} * {count_index} = {calc_number * count_index} -> result: {result}')
                        count_index += 1
                        number_of_digits -= 1
                else:
                    rangenumber = number_of_digits
                    for i in range(0, rangenumber):
                        print('.')
                        count_index += 1
                        number_of_digits -= 1
        else:
            for index_digits in (range(0, number_of_digits)):
                result += current_digit * count_index
                print(f'{current_digit} * {count_index} = {current_digit * count_index} -> result: {result}')
                count_index += 1
            
        current_digit += 1
    input[index] = 0
    
print(f'Result: {result}')

print_runtime(start_time)