from Helper import *

def get_direction(move):
    match move:
        case '^': return (-1, 0)
        case 'v': return (1, 0)
        case '>': return (0, 1)
        case '<': return (0, -1)
    return Exception(f'Invalid move: {move}')

def get_node_after_boxes(matrix, node, direction, character):
    while character in ['[', ']']:
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
            char_list = list()
            for char in line:
                match char:
                    case '#': 
                        char_list.append('#')
                        char_list.append('#')
                    case '@': 
                        char_list.append('@')
                        char_list.append('.')
                    case 'O': 
                        char_list.append('[')
                        char_list.append(']')
                    case '.': 
                        char_list.append('.')
                        char_list.append('.')
            matrix.append(char_list)
        else:
            moves += line

print_matrix(matrix)

current_node = get_first_node_with(matrix, '@')
print(f'Robot starts at {current_node}')
for move in moves:
    print(f'Move: {move}')
    direction = get_direction(move)
    next_node, next_character = get_next_node(matrix, current_node, direction)

    match next_character:
        case '[' | ']' : 
            node_after_boxes, char_after_boxes = get_node_after_boxes(matrix, next_node, direction, next_character)
            if char_after_boxes == '.':
                current_row, current_col = current_node
                next_row, next_col = next_node
                after_boxes_row, after_boxes_col = node_after_boxes
                match move:
                    case '>':
                        for i in range(after_boxes_col, current_col, -1):
                            matrix[current_row][i] = matrix[current_row][i-1]
                        matrix[current_row][current_col] = '.'
                    case '<':
                        for i in range(after_boxes_col,current_col):
                            matrix[current_row][i] = matrix[current_row][i+1]
                        matrix[current_row][current_col] = '.'

                current_node = next_node           

        case '.': 
            current_row, current_col = current_node
            next_row, next_col = next_node
            matrix[current_row][current_col] = '.'
            matrix[next_row][next_col] = '@'
            current_node = next_node

    print_matrix(matrix)

# result = 0
# for box in get_nodes_with(matrix, 'O'):
#     row, col = box
#     result += 100*row + col

# print(f'Result: {result}')
print_runtime(start_time)