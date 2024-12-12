import time
import os

def print_runtime(start_time):
    end_time = time.time()
    runtime = end_time - start_time
    print(f"Runtime: {runtime} seconds")

def initialize():
    start_time = time.time()
    year = 2024
    file_name = os.path.basename(__file__)
    print(f'{year} - {file_name}')
    return start_time

def print_matrix(matrix):
    for row in matrix:
        print(" ".join(str(element) for element in row))

def get_unique_characters(matrix):
    unique_chars = set()
    for row in matrix:
        for char in row:
            unique_chars.add(char)
    return unique_chars

def get_nodes_with(char, matrix):
    nodes = list()
    for i, row in enumerate(matrix):
        for j, element in enumerate(row):
            if element == char:
                nodes.append((i,j))
    return nodes

def inBounds(rows, cols, node):
    row, col = node
    return 0 <= row < rows and 0 <= col < cols

def get_next_node(matrix, node, direction):
    row, col = node
    dx, dy = directions[direction]
    return matrix[row + dx][col + dy]


def get_heigth(matrix, node):
    row, col = node
    return matrix[row][col]

