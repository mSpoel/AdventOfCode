
print('2021 - Day01 - Part 1')
file= open("../../../Data/2021/Day02/input.txt", "r")

horizontal = 0
depth = 0
aim = 0

for line in file:
	movement = line.split()[0];
	value = int(line.split()[1]);

	match movement:
		case 'forward':
			horizontal += value
			depth += (aim * value)
		case 'down':
			aim += value
		case 'up':
			aim -= value
	
	print('movement: ', movement, ' value:', value, ' horizontal:', horizontal, ' depth:', depth, ' aim: ', aim)

result = horizontal * depth
	
print('result:', result)
