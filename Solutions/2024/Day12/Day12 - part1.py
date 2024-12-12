from Helper import *

def flood_fill(matrix, x, y, visited, char):
    stack = [(x, y)]
    region_nodes = []

    while stack:
        cx, cy = stack.pop()
        if cx < 0 or cx >= len(matrix) or cy < 0 or cy >= len(matrix[0]) or visited[cx][cy] or matrix[cx][cy] != char:
            continue

        visited[cx][cy] = True
        region_nodes.append((cx, cy))

        # Visit all 8 neighbors (up, down, left, right, and diagonals)
        directions = [(-1, 0), (1, 0), (0, -1), (0, 1), (-1, -1), (-1, 1), (1, -1), (1, 1)]
        for dx, dy in directions:
            stack.append((cx + dx, cy + dy))

    return region_nodes

def get_unique_regions(matrix):
    if not matrix:
        return []

    rows, cols = len(matrix), len(matrix[0])
    visited = [[False for _ in range(cols)] for _ in range(rows)]
    regions = []

    for i in range(rows):
        for j in range(cols):
            if not visited[i][j]:
                char = matrix[i][j]
                region_nodes = flood_fill(matrix, i, j, visited, char)
                regions.append(region_nodes)

    return regions

def calculate_perimeter(nodes):
    nodes_set = set(nodes)
    perimeter = 0
    for node in nodes:
        row, col = node
        # Check the 4 direct neighbors
        neighbor_offsets = [(1, 0), (0, 1), (-1, 0), (0, -1)]
        node_perimeter = 4
        for dr, dc in neighbor_offsets:
            if (row + dr, col + dc) in nodes_set:
                node_perimeter -= 1
        perimeter += node_perimeter

    return perimeter

start_time = initialize()

with open("/workspaces/AdventOfCode/Solutions/2024/Day12/example.txt", "r") as file:
    matrix = [line.strip() for line in file]

print_matrix(matrix)
result = 0

for region in get_unique_regions(matrix):
    perimeter = calculate_perimeter(region)
    number_of_nodes = len(region)
    price = perimeter * number_of_nodes
    print(f'perimeter: {perimeter} - number of nodes: {number_of_nodes} - price {price}')
    result += price

print(f'Result: {result}')

print_runtime(start_time)