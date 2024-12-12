from Helper import *

def flood_fill(matrix, x, y, visited, char, region_nodes):
    if (x < 0 or x >= len(matrix) or
        y < 0 or y >= len(matrix[0]) or
        visited[x][y] or matrix[x][y] != char):
        return

    visited[x][y] = True
    region_nodes.append((x, y))

    # Visit all 8 neighbors (up, down, left, right, and diagonals)
    directions = [(-1, 0), (1, 0), (0, -1), (0, 1),
                  (-1, -1), (-1, 1), (1, -1), (1, 1)]

    for dx, dy in directions:
        flood_fill(matrix, x + dx, y + dy, visited, char, region_nodes)

def get_unique_regions(matrix):
    if not matrix:
        return {}

    rows, cols = len(matrix), len(matrix[0])
    visited = [[False for _ in range(cols)] for _ in range(rows)]
    regions = []

    for i in range(rows):
        for j in range(cols):
            if not visited[i][j]:
                char = matrix[i][j]
                region_nodes = []
                flood_fill(matrix, i, j, visited, char, region_nodes)
                regions.append(region_nodes)

    return regions

def get_neighbour_nodes(node):
    row, col = node
    neighbours = []
    neighbours.append((row+1, col))
    neighbours.append((row, col+1))
    neighbours.append((row-1, col))
    neighbours.append((row, col-1))
    return neighbours

def calculate_perimeter(nodes):
    perimeter = 0
    for node in nodes:
        node_perimeter = 4
        for neighbour_node in get_neighbour_nodes(node):
            if neighbour_node in nodes:
                node_perimeter -= 1
        perimeter += node_perimeter

    return perimeter

start_time = initialize()

with open("/workspaces/AdventOfCode/Solutions/2024/Day12/input.txt", "r") as file:
    matrix = [line.strip() for line in file]

print_matrix(matrix)
rows = len(matrix)
cols = len(matrix[0]) if rows > 0 else 0
result = 0

for region in get_unique_regions(matrix):
    perimeter = calculate_perimeter(region)
    number_of_nodes = len(region)
    price = perimeter * number_of_nodes
    print(f'perimeter: {perimeter} - number of nodes: {number_of_nodes} - price {price}')
    result += price

print(f'Result: {result}')

print_runtime(start_time)