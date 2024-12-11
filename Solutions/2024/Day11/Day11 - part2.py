from Helper import *
from collections import Counter, defaultdict

result = 0

#here we keep the count of the stones and store that
#I was struggling to get the structure correct and didn't want to loose too much time today, so Reddit helped me.
#this is not my code, I got it from https://github.com/anviks/AOC/blob/master/2024/day_11/solution.py
#Thank you for this python lesson!
def blink(c1: Counter):
    c2 = defaultdict(int)

    for stone, count in c1.items():
        if stone == 0:
            c2[1] += c1[0]
        elif len(str(stone)) % 2 == 0:
            s = str(stone)
            s1, s2 = int(s[:len(s) // 2]), int(s[len(s) // 2:])
            c2[s1] += c1[stone]
            c2[s2] += c1[stone]
        else:
            c2[stone * 2024] += c1[stone]

    return c2

start_time = initialize()
result = 0

with open("/workspaces/AdventOfCode/Solutions/2024/Day11/input.txt", "r") as file:
    matrix = [[int(value) for value in line.split()] for line in file]
data = matrix[0]

c = Counter(data) #Today I learned about the Counter class
for _ in range(75):
    c = blink(c)

result = sum(c.values())

print(result)
print_runtime(start_time)