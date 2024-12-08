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

def get_antinodes(node, nodes, max_row, max_col):
    antinodes = list()
    row, col = node

    for next_node in nodes:
        next_row, next_col = next_node
        dx = next_row - row
        dy = next_col - col
        print(f'node: {node} - next node {next_node}: dx: {dx} - dy {dy}')

        antinode1_row = row - dx
        antinode1_col = col - dy
        while(0 <= antinode1_row < max_row and 0 <= antinode1_col < max_col):
            antinode1 = (antinode1_row, antinode1_col)
            antinodes.append(antinode1)
            print(f'antinode 1: {antinode1}')
            antinode1_row = antinode1_row - dx
            antinode1_col = antinode1_col - dy

        antinode2_row = row + dx
        antinode2_col = col + dy
        while(0 <= antinode2_row < max_row and 0 <= antinode2_col < max_col):
            antinode2 = (antinode2_row, antinode2_col)
            antinodes.append(antinode2)
            print(f'antinode 2: {antinode2}')
            antinode2_row = antinode2_row + dx
            antinode2_col = antinode2_col + dy
    return antinodes

start_time = initialize()

with open("/workspaces/AdventOfCode/Solutions/2024/Day08/input.txt", "r") as file:
    matrix = [list(line.strip()) for line in file]

print_matrix(matrix)

unique_characters = get_unique_characters(matrix)

print(unique_characters)

antinodes = set()
max_row = len(matrix)
max_col = len(matrix[0])

for unique_character in unique_characters:
    print(unique_character)
    nodes = get_nodes_with(unique_character, matrix)
    print(nodes)
    for i in range(len(nodes)):
        antinodes.add(nodes[i])
        for antinode in get_antinodes(nodes[i], nodes[i+1:], max_row, max_col):
            antinodes.add(antinode)

print(f'Result: {len(antinodes)}')

# for antinode in antinodes:
#     row, col = antinode
#     matrix[row][col] = '#'

# print_matrix(matrix)

print_runtime(start_time)