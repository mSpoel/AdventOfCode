print('2021 - Day01 - Part 2')
file= open("../../../Data/2021/Day01/input.txt", "r")

input = []

for line in file:
	input.append(int(line))
	
count_diff = 0
prev_val = sum(input[0:3])
for i in range(1, len(input) - 2):
	cur_val = sum(input[i:i+3])
	if cur_val > prev_val:
		count_diff += 1
	prev_val = cur_val

print('Number of increases: ', count_diff)
