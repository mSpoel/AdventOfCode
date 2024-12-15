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

# def print_matrix(matrix):
#     os.system('clear')
#     for row in matrix:
#         print("".join("🤖" if element == '@' 
#                       else "🧱" if element == '#' 
#                       else "📦" if element == 'O' 
#                       else "  " if element == '.'
#                       else element.ljust(2) for element in row))

def print_matrix(matrix):
    for row in matrix:
        print("".join(row))

def inBounds(rows, cols, node):
    row, col = node
    return 0 <= row < rows and 0 <= col < cols

def get_next_node(matrix, node, direction):
    row, col = node
    dx, dy = direction
    return (row + dx, col + dy), matrix[row + dx][col + dy]

def get_heigth(matrix, node):
    row, col = node
    return matrix[row][col]

def get_first_node_with(matrix, char):
    rows = len(matrix)
    cols = len(matrix[0])
    for i in range(0, rows):
        for j in range(0, cols):
            if matrix[i][j] == char:
                return i,j
    return None

def get_nodes_with(matrix, char):
    nodes = list()
    rows = len(matrix)
    cols = len(matrix[0])
    for i in range(0, rows):
        for j in range(0, cols):
            if matrix[i][j] == char:
                nodes.append((i,j))
    return nodes