print('2022 - Day02 - Part 1')
file= open("/workspaces/AdventOfCode/Solutions/2024/Day02/input.txt", "r")

numberOfSafe = 0
for line in file:
    print(line)
    numbers = line.split()
    prevDiff = int(numbers[1]) - int(numbers[0])
    safe = True

    for i in range(1, len(numbers) - 1):

        diff = int(numbers[i+1]) - int(numbers[i])        

        if(diff == 0 or abs(diff) > 3):
            safe = False
            print('Diff not in range: ', diff)
        if((prevDiff < 0 and diff > 0)):
            safe = False
            print('Not decreasing or too much ', diff)
        elif((prevDiff > 0 and diff < 0 )):
            safe = False
            print('Not increasing or too much ', diff)

    print('line is ', safe)
    if(safe):
        numberOfSafe += 1

print('Number of safe lines: ', numberOfSafe)