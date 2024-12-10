from Helper import *

directions = [(-1, 0), (0, 1), (1, 0), (0, -1)]

def get_number_of_hikes(node, start_height, max_height):
    current_height = start_height
    next_nodes = get_next_nodes(matrix, node, start_height)
    while len(next_nodes) > 0:
        current_height += 1

        if current_height == max_height:
            return len(next_nodes)
        
        next_next_nodes = set()
        for next_node in next_nodes:
            next_next_nodes.update(get_next_nodes(matrix, next_node, current_height))
        
        next_nodes = next_next_nodes
    return 0

def get_next_nodes(matrix, node, current_height):
    next_nodes = set()
    row, col = node
    
    for dx, dy in directions:
        next_row = row + dx
        next_col = col + dy
        if 0 <= next_row < rows and 0 <= next_col < cols:
            next_height = matrix[next_row][next_col]
            if next_height - current_height == 1:
                next_nodes.add((next_row, next_col))

    return next_nodes

start_time = initialize()
result = 0

with open("/workspaces/AdventOfCode/Solutions/2024/Day10/example.txt", "r") as file:
    matrix = [[int(char) for char in line.strip()] for line in file]

print_matrix(matrix)
rows = len(matrix)
cols = len(matrix[0]) if rows > 0 else 0

nodes = get_nodes_with(0, matrix)
print(nodes)

max_heigth = 9
#possible_paths = len(nodes)

for node in nodes:
    number_of_nodes = len(node)
    print(f'node: {node}')
    current_height = 0
    possible_paths = 1
    next_nodes = get_next_nodes(matrix, node, current_height)
    while len(next_nodes) > 0:
        possible_paths += len(next_nodes) - 1
        current_height += 1

        #todo: make sure the paths are counted correctly
        print(f'possible paths: {possible_paths} - nodes: {next_nodes} - current_height {current_height}')

        next_next_nodes = set()
        for next_node in next_nodes:
            next_next_nodes.update(get_next_nodes(matrix, next_node, current_height))

        next_nodes = next_next_nodes

print(f'Result: {result}')

print_runtime(start_time)