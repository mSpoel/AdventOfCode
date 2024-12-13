from Helper import *
import re

def is_integer(value):
    return isinstance(value, int) or (isinstance(value, float) and value.is_integer())

#based on Cramer's rule
def get_costs(x1, x2, y1, y2, p1, p2):
    b = (p1*y1 - x1*p2)/(y1*x2-x1*y2)
    a = (p2 - y2*b)/y1

    if(is_integer(a) and is_integer(b) and a <= 100 and b <= 100):
        print(f'a: {a} - b: {b}')
        return int(3*a + b) 

    return 0

start_time = initialize()

# Open and read the file
with open("/workspaces/AdventOfCode/Solutions/2024/Day13/input.txt", "r") as file:
    data = file.read()

# Find all matches for Button A, Button B, and Prize using regex
button_a_matches = re.findall(r"Button A: X\+(\d+), Y\+(\d+)", data)
button_b_matches = re.findall(r"Button B: X\+(\d+), Y\+(\d+)", data)
prize_matches = re.findall(r"Prize: X=(\d+), Y=(\d+)", data)

result = 0

for i in range(0, len(button_a_matches)):
    button_a = button_a_matches[i]
    button_b = button_b_matches[i]
    prize_match = prize_matches[i]
    result += get_costs(
        int(button_a[0]), 
        int(button_b[0]), 
        int(button_a[1]), 
        int(button_b[1]), 
        int(prize_match[0]), 
        int(prize_match[1]))

print(f'Result: {result}')

print_runtime(start_time)