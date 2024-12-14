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
        print("".join('.' if element == 0 else str(element) for element in row))

def print_green_matrix(matrix):
    for row in matrix:
        formatted_row = "".join(f"\033[32m{str(element)}\033[0m" if element != 0 else '.' for element in row)
        print(formatted_row)