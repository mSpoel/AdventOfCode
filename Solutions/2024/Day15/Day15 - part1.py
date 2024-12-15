from Helper import *
from PIL import Image, ImageDraw, ImageFont

def matrix_to_image(matrix, font):
    width = len(matrix[0]) * 20
    height = len(matrix) * 20
    image = Image.new('RGB', (width, height), color='white')
    draw = ImageDraw.Draw(image)
    
    for y, row in enumerate(matrix):
        for x, element in enumerate(row):
            emoji = "🤖" if element == '@' else "🧱" if element == '#' else "📦" if element == 'O' else "  " if element == '.' else element
            draw.text((x * 20, y * 20), emoji, font=font, fill='black')
    
    return image

# Load a font
font = ImageFont.load_default()
frames = []

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
with open("/workspaces/AdventOfCode/Solutions/2024/Day15/smallexample.txt", "r") as file:
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
print(moves)

current_node = get_first_node_with(matrix, '@')
print(f'Robot starts at {current_node}')
for move in moves:
    # print(f'Robot is at {current_node}')
    direction = get_direction(move)
    next_node, next_character = get_next_node(matrix, current_node, direction)
    formatted_direction = f"({direction[0]: >2}, {direction[1]: >2})"
    formatted_next_node = f"({next_node[0]: >3}, {next_node[1]: >3})"
    # print(f'Next move {move}: direction {formatted_direction} to {formatted_next_node}: {next_character}')

    match next_character:
        # case '#': 
            # print('Wall')
        case 'O': 
            # print('Box')
            node_after_boxes, char_after_boxes  = get_node_after_boxes(matrix, next_node, direction)
            if char_after_boxes == '.':
                current_row, current_col = current_node
                next_row, next_col = next_node
                after_boxes_row, after_boxes_col = node_after_boxes
                matrix[current_row][current_col] = '.'
                matrix[next_row][next_col] = '@'
                matrix[after_boxes_row][after_boxes_col] = 'O'
                current_node = next_node           

        case '.': 
            # print('Lets move')
            current_row, current_col = current_node
            next_row, next_col = next_node
            matrix[current_row][current_col] = '.'
            matrix[next_row][next_col] = '@'
            current_node = next_node
    
    image = matrix_to_image(matrix, font)
    frames.append(image)    
    # print_matrix(matrix)

# Save frames as a GIF
frames[0].save('/workspaces/AdventOfCode/Solutions/2024/Day15/output.gif', save_all=True, append_images=frames[1:], duration=500, loop=0)

result = 0
for box in get_nodes_with(matrix, 'O'):
    row, col = box
    result += 100*row + col

print(f'Result: {result}')
print_runtime(start_time)