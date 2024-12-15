from Helper import *

def get_direction(move):
    match move:
        case '^': return (-1, 0)
        case 'v': return (1, 0)
        case '>': return (0, 1)
        case '<': return (0, -1)
    return Exception(f'Invalid move: {move}')

def get_node_after_boxes(matrix, node, direction):
    character = 'O'
    while character == 'O':
        node, character = get_next_node(matrix, node, direction)

    return node, character

start_time = initialize()

matrix = []
moves = ""
with open("/workspaces/AdventOfCode/Solutions/2024/Day15/example.txt", "r") as file:
    isMatrixPart = True
    for line in file:
        line = line.strip()
        if not line:
            isMatrixPart = False
            continue
        
        if isMatrixPart:
            matrix.append(list(line))  # Convert each row to a list of characters
        else:
            moves += line

print_matrix(matrix)
# print(moves)

current_node = get_first_node_with(matrix, '@')
print(f'Robot starts at {current_node}')
for move in moves:
    direction = get_direction(move)
    next_node, next_character = get_next_node(matrix, current_node, direction)

    match next_character:
        case 'O': 
            node_after_boxes, char_after_boxes = get_node_after_boxes(matrix, next_node, direction)
            if char_after_boxes == '.':
                current_row, current_col = current_node
                next_row, next_col = next_node
                after_boxes_row, after_boxes_col = node_after_boxes
                matrix[current_row][current_col] = '.'
                matrix[next_row][next_col] = '@'
                matrix[after_boxes_row][after_boxes_col] = 'O'
                current_node = next_node           

        case '.': 
            current_row, current_col = current_node
            next_row, next_col = next_node
            matrix[current_row][current_col] = '.'
            matrix[next_row][next_col] = '@'
            current_node = next_node

    print_matrix(matrix)
    time.sleep(0.05)  

result = 0
for box in get_nodes_with(matrix, 'O'):
    row, col = box
    result += 100*row + col

print(f'Result: {result}')
print_runtime(start_time)