from Helper import *
import random

def flood_fill(matrix, x, y, visited, char):
    stack = [(x, y)]
    region_nodes = []

    while stack:
        cx, cy = stack.pop()
        if (cx < 0 or cx >= len(matrix) or
            cy < 0 or cy >= len(matrix[0]) or
            visited[cx][cy] or matrix[cx][cy] != char):
            continue

        visited[cx][cy] = True
        region_nodes.append((cx, cy))

        # Visit only 4 neighbors (up, down, left, right)
        directions = [(-1, 0), (1, 0), (0, -1), (0, 1)]
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
        neighbor_offsets = [(-1, 0), (1, 0), (0, -1), (0, 1)]
        node_perimeter = 4
        for dr, dc in neighbor_offsets:
            neighbor = (row + dr, col + dc)
            if neighbor in nodes_set:
                node_perimeter -= 1
        perimeter += node_perimeter

    return perimeter

def print_colored_matrix(matrix, regions):
    colored_matrix = [list(row) for row in matrix]
    colors = ['\033[91m', '\033[92m', '\033[93m', '\033[94m', '\033[95m', '\033[96m', '\033[97m']

    for region in regions:
        color = random.choice(colors)
        for (x, y) in region:
            colored_matrix[x][y] = f"{color}{matrix[x][y]}\033[0m"

    for row in colored_matrix:
        print("".join(row))

def print_region(matrix, region):
    region_matrix = [list(row) for row in matrix]
    for (x, y) in region:
        region_matrix[x][y] = f"\033[91m{matrix[x][y]}\033[0m"
    for row in region_matrix:
        print("".join(row))

start_time = initialize()

with open("/workspaces/AdventOfCode/Solutions/2024/Day12/input.txt", "r") as file:
    matrix = [line.strip() for line in file]

print("Original Matrix:")
print_matrix(matrix)

regions = get_unique_regions(matrix)
result = 0

for region in regions:
    perimeter = calculate_perimeter(region)
    number_of_nodes = len(region)
    price = perimeter * number_of_nodes
    print(f'perimeter: {perimeter} - number of nodes: {number_of_nodes} - price {price}')
    # print("Region Structure:")
    # print_region(matrix, region)
    result += price

print("Colored Matrix with Regions:")
print_colored_matrix(matrix, regions)

print(f'Result: {result}')
print_runtime(start_time)