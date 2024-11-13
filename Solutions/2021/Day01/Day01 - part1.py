print('2021 - Day01 - Part 1')
file= open("../../../Data/2021/Day01/input_part1.txt", "r")

current = 0
numberOfIncreases = -1 #first line doesnt count as increase
numberOfDecreases = 0

for line in file:
	y = int(line)
	print('Current:', current, ' - next: ', y)
	if y > current:
		numberOfIncreases = numberOfIncreases + 1
	else:
		numberOfDecreases = numberOfDecreases + 1
	current = y


print('Number of increases: ', numberOfIncreases)
print('Number of decreases: ', numberOfDecreases)
		
