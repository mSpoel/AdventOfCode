import copy
import time

start_time = time.time()

print('2024 - Day06 - Part 2')

def find_first_occurrence(matrix, char):
    for i, row in enumerate(matrix):
        for j, element in enumerate(row):
            if element == char:
                return i, j
    return None

def count_character(matrix, char):
    count = 0
    for row in matrix:
        count += row.count(char)
    return count

def move(position, direction):
    row, col = position
    dx, dy = directions[direction]
    return row + dx, col + dy

def get_character(matrix, position):
    row, col = position
    return matrix[row][col]

def get_next_character(matrix, position, direction):
    row, col = position
    dx, dy = directions[direction]
    return matrix[row + dx][col + dy]

def get_next_direction(direction_matrix, position, direction):
    row, col = position
    dx, dy = directions[direction]
    return direction_matrix[row + dx][col + dy]

def set_character(matrix, position, char):
    row, col = position
    matrix[row][col] = char

def set_move_character(matrix, position, direction):
    row, col = position
    if matrix[row][col] == '+':
        return
    if (direction == 0 or direction == 2):
        if matrix[row][col] == '-':
            char = '+'
        else:
            char = '|'
    else:
        if matrix[row][col] == '|':
            char = '+'
        else:
            char = '-'
    matrix[row][col] = char

def set_direction(direction_matrix, position, direction):
    row, col = position
    direction_matrix[row][col] = direction

def inBounds(matrix, position, direction):
    rows = len(matrix)
    cols = len(matrix[0]) if rows > 0 else 0
    row, col = position
    dx, dy = directions[direction]
    return 0 <= row + dx < rows and 0 <= col + dy < cols

def turnRight(direction):
    if direction == 3:
        direction = -1
    direction += 1
    return direction

directions = [(-1, 0), (0, 1), (1, 0), (0, -1)]
crate = 'O' 

def place_crate(matrix, position):
    row, col = position
    matrix[row][col] = crate

def get_direction(direction_matrix, position):
    row, col = position
    return direction_matrix[row][col]

def visited_before(visits, position, direction):
    visit = (position, direction)
    if visit in visits:
        return True
    
    visits.add(visit)
    return False

def isLoop(matrix, position, direction):
    visits = set()
    while inBounds(matrix, position, direction):
        nextChar = get_next_character(matrix, position, direction)
 
        while nextChar == '#' or nextChar == crate:
            if visited_before(visits, position, direction):
                return True

            direction = turnRight(direction)
            set_character(matrix, position, '+')
            nextChar = get_next_character(matrix, position, direction)        
        position = move(position, direction)
        set_move_character(matrix, position, direction)
        
    return False    

with open("/workspaces/AdventOfCode/Solutions/2024/Day06/input.txt", "r") as file:
    matrix = [list(line.strip()) for line in file]

position = find_first_occurrence(matrix, '^')
start_position = position
result = 0
positions = set()
direction = 0

# Get the position on the path, only place crates there
while inBounds(matrix, position, direction):   
    set_character(matrix, position, 'X')
    nextChar = get_next_character(matrix, position, direction)
    if nextChar == '#':
        direction = turnRight(direction)
       
    position = move(position, direction)
    positions.add(position)   

for crate_position in positions:
    copy_matrix = copy.deepcopy(matrix)
    place_crate(copy_matrix, crate_position)
    print(f'Checking for {crate_position}')
    if isLoop(copy_matrix, start_position, 0):
        result += 1
        print(f'result: {result}')

print('result:', result)

end_time = time.time()
runtime = end_time - start_time
print(f"Runtime: {runtime} seconds")