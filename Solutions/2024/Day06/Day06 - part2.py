import copy

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

def isLoop(matrix, position, direction):
    rows = len(matrix)
    cols = len(matrix[0])
    direction_matrix = [[-1 for _ in range(cols)] for _ in range(rows)]

    while inBounds(matrix, position, direction):    
        nextChar = get_next_character(matrix, position, direction)
        nextDirection = get_next_direction(direction_matrix, position, direction)

        currentChar = get_character(matrix, position)
        if currentChar == '+' and nextDirection == direction:
            return True


        # if nextChar == '+' or (nextChar == '|' and (direction == 0 or direction == 2)) or (nextChar == '-' and (direction == 1 or direction == 3)):
        #    storedDirection = get_direction(direction_matrix, position)
        #    return storedDirection == nextDirection

        while nextChar == '#' or nextChar == crate:
            direction = turnRight(direction)
            set_character(matrix, position, '+')
            set_direction(direction_matrix, position, direction)
            nextChar = get_next_character(matrix, position, direction)
        
        position = move(position, direction)
        set_move_character(matrix, position, direction)
        set_direction(direction_matrix, position, direction)

    return False

with open("/workspaces/AdventOfCode/Solutions/2024/Day06/example.txt", "r") as file:
    matrix = [list(line.strip()) for line in file]

position = find_first_occurrence(matrix,  '^')

rows = len(matrix)
cols = len(matrix[0])

result = 0

# crate_position = (8, 1)
# place_crate(matrix, crate_position)
# isLoop(matrix, position, 0)

for row in range(0, rows):
    for col in range(0, cols):
        copy_matrix = copy.deepcopy(matrix)
        crate_position = (row, col)
        place_crate(copy_matrix, crate_position)
        print(f'Checking for {crate_position}')
        if isLoop(copy_matrix, position, 0):
            result += 1
            print(f'result: {result}')

print('result:', result)