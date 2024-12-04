print('2024 - Day04 - Part 2')
with open("../../../Data/2024/Day04/input.txt", "r") as file:
    matrix = [list(line.strip()) for line in file]

numberOfRows = len(matrix)
numberOfColumns = len(matrix[0])
print(numberOfRows , ' rows ' , numberOfColumns, ' columns')

numberOfXmas = 0
for row in range(1, numberOfRows-1):
    for col in range(1, numberOfColumns-1):
        if (matrix[row][col] == 'A'):
            word1 = matrix[row-1][col-1] + matrix[row][col] + matrix[row+1][col+1]
            word2 = matrix[row+1][col-1] + matrix[row][col] + matrix[row-1][col+1]
            if((word1 == 'MAS' or word1 == 'SAM') and (word2 == 'MAS' or word2 == 'SAM')):
                numberOfXmas += 1

print(numberOfXmas)

#Copilot suggestion
print('2024 - Day04 - Part 2')

# Use a context manager to open the file
# with open("/workspaces/AdventOfCode/Solutions/2024/Day04/input.txt", "r") as file:
#     matrix = [list(line.strip()) for line in file]

# numberOfRows = len(matrix)
# numberOfColumns = len(matrix[0])
# print(f'{numberOfRows} rows, {numberOfColumns} columns')

# def check_diagonals(matrix, row, col):
#     word1 = matrix[row-1][col-1] + matrix[row][col] + matrix[row+1][col+1]
#     word2 = matrix[row+1][col-1] + matrix[row][col] + matrix[row-1][col+1]
#     return (word1 in {'MAS', 'SAM'}) and (word2 in {'MAS', 'SAM'})

# numberOfXmas = sum(
#     check_diagonals(matrix, row, col)
#     for row in range(1, numberOfRows-1)
#     for col in range(1, numberOfColumns-1)
#     if matrix[row][col] == 'A'
# )

# print(numberOfXmas)