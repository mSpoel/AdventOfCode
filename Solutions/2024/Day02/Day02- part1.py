print('2022 - Day02 - Part 1')
file = open("/workspaces/AdventOfCode/Solutions/2024/Day02/input.txt", "r")
numberOfSafe = 0
for line in file:
    print(line)
    numbers = list(map(int, line.split()))
    safe = True

    for i in range(len(numbers) - 1):
        diff = numbers[i + 1] - numbers[i]

        if diff == 0 or abs(diff) > 3:
            safe = False
            print('Diff not in range: ', diff)
            break
        if i > 0:
            prevDiff = numbers[i] - numbers[i - 1]
            if (prevDiff < 0 and diff > 0) or (prevDiff > 0 and diff < 0):
                safe = False
                print('Not consistent: ', diff)
                break

    print('line is ', safe)
    if safe:
        numberOfSafe += 1

file.close()
print('Number of safe lines: ', numberOfSafe)