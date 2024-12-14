from Helper import *

class Robot:
    def __init__(self, p, v):
        self.p = p
        self.v = v

    def __repr__(self):
        return f"Robot(p={self.p}, v={self.v})"

def write_matrix_to_file(file_path, matrix, seconds):
    with open(file_path, 'a') as file:
        file.write(f'Seconds: {seconds}\n')
        for row in matrix:
            formatted_row = "".join(f"{element}" if element != 0 else '.' for element in row)
            file.write(f"{formatted_row}\n")
        file.write('\n')

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

mid_col = int((cols-1)/2) 
for step in range(1, 10):
    for seconds in range((step-1)*1000, step*1000):
        matrix = [[0 for _ in range(cols)] for _ in range(rows)]
        for robot in robots:
            col, row = move_robot(robot, seconds)
            matrix[row][col] += 1
        
        draw = True
        for r in range(0, rows):
            if matrix[r][mid_col] == 0:
                draw = False

            if draw:      
                # print(f'Seconds: {seconds}')
                # print_green_matrix(matrix)
                write_matrix_to_file(f'/workspaces/AdventOfCode/Solutions/2024/Day14/outfiltered.txt', matrix, seconds)

print_runtime(start_time)