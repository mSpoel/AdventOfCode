from Helper import *

class Robot:
    def __init__(self, p, v):
        self.p = p
        self.v = v

    def __repr__(self):
        return f"Robot(p={self.p}, v={self.v})"

def get_sum(matrix, start_row, start_col, end_row, end_col):
    sum = 0
    for i in range(start_row, end_row):
        for j in range(start_col, end_col):
            sum += matrix[i][j]
    return sum

def parse_line(line):
    p_part, v_part = line.split(' ')
    p = tuple(map(int, p_part.split('=')[1].split(',')))
    v = tuple(map(int, v_part.split('=')[1].split(',')))
    return Robot(p, v)

def read_file(file_path):
    robots = []
    with open(file_path, 'r') as file:
        for line in file:
            robots.append(parse_line(line.strip()))
    return robots

def move_robot(robot, moves):
    col, row = robot.p
    vcol, vrow = robot.v

    new_col = (vcol*moves + col)%cols
    new_row = (vrow*moves + row)%rows 

    return new_col, new_row

start_time = initialize()
file = 'input'
rows, cols = 103, 101
if file == 'example':
    rows, cols = 11,7

robots = read_file(f"/workspaces/AdventOfCode/Solutions/2024/Day14/{file}.txt")
for robot in robots:
    print(robot)

matrix = [[0 for _ in range(cols)] for _ in range(rows)]

for robot in robots:
    col, row = move_robot(robot, 100)
    matrix[row][col] += 1
print_matrix(matrix)

mid_row = int((rows-1)/2)
mid_col = int((cols-1)/2) 
print(f'mid: {mid_row},{mid_col}')

q1 = get_sum(matrix, 0, 0, mid_row, mid_col)
q2 = get_sum(matrix, 0, mid_col+1, mid_row, cols)
q3 = get_sum(matrix, mid_row+1, 0, rows, mid_col)
q4 = get_sum(matrix, mid_row+1, mid_col+1, rows, cols)

print(f'q1:{q1} q2:{q2} q3:{q3} q4:{q4}')
result = q1*q2*q3*q4
print(f'Result: {result}')

print_runtime(start_time)