from Helper import *

def get_unique_characters(matrix):
    unique_characters = set(char for row in matrix for char in row)
    unique_characters.remove('.')
    return unique_characters

def get_nodes_with(char, matrix):
    nodes = list()
    for i, row in enumerate(matrix):
        for j, element in enumerate(row):
            if element == char:
                nodes.append((i,j))
    return nodes

def get_antinodes(node, nodes):
    antinodes = list()
    row, col = node

    for next_node in nodes:
        next_row, next_col = next_node
        dx = next_row - row
        dy = next_col - col
        print(f'node: {node} - next node {next_node}: dx: {dx} - dy {dy}')

        antinode1 = (row - dx, col - dy)
        antinode2 = (next_row + dx, next_col + dy)
        print(f'antinode 1: {antinode1} - antinode 2: {antinode2}')
        antinodes.append(antinode1)
        antinodes.append(antinode2) 
    return antinodes

def inBounds(matrix, antinode):
    row, col = antinode
    rows = len(matrix)
    cols = len(matrix[0]) if rows > 0 else 0
    return 0 <= row < rows and 0 <= col < cols

start_time = initialize()

with open("/workspaces/AdventOfCode/Solutions/2024/Day08/input.txt", "r") as file:
    matrix = [list(line.strip()) for line in file]

print_matrix(matrix)

unique_characters = get_unique_characters(matrix)

print(unique_characters)

antinodes = set()
for unique_character in unique_characters:
    print(unique_character)
    nodes = get_nodes_with(unique_character, matrix)
    print(nodes)
    for i in range(len(nodes)):
        for antinode in get_antinodes(nodes[i], nodes[i+1:]):
            if inBounds(matrix, antinode):
                antinodes.add(antinode)

print(f'Result: {len(antinodes)}')
print_runtime(start_time)