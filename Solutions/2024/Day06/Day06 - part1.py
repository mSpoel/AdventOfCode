print('2024 - Day06 - Part 1')

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

def set_character(matrix, position, char):
    row, col = position
    matrix[row][col] = char

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

with open("/workspaces/AdventOfCode/Solutions/2024/Day06/input.txt", "r") as file:
    matrix = [list(line.strip()) for line in file]

position = find_first_occurrence(matrix,  '^')
direction = 0

print(f'Start position: {position}')

while inBounds(matrix, position, direction):   
    set_character(matrix, position, 'X')
    
    nextChar = get_next_character(matrix, position, direction)

    if nextChar == '#':
        print(f'Hit # at {position} with direction {directions[direction]}')
        direction = turnRight(direction)
       
    position = move(position, direction)
    print(f'Current position: {position}')

numberOfX = count_character(matrix, 'X') + 1
print(f'Result: {numberOfX}')