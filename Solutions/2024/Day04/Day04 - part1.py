print('2024 - Day04 - Part 1')
with open("/workspaces/AdventOfCode/Solutions/2024/Day04/input.txt", "r") as file:
    matrix = [list(line.strip()) for line in file]

numberOfRows = len(matrix)
numberOfColumns = len(matrix[0])
print(numberOfRows , ' rows ' , numberOfColumns, ' columns')

numberOfXmas = 0
for row in range(0, numberOfRows):
    for col in range(0, numberOfColumns):
        if (matrix[row][col] == 'X'):
            if(row > 2):
                word = matrix[row][col] + matrix[row-1][col] + matrix[row-2][col] + matrix[row-3][col]
                if(word == 'XMAS'):
                    numberOfXmas += 1
            if(numberOfRows - row > 3):
                word = matrix[row][col] + matrix[row+1][col] + matrix[row+2][col] + matrix[row+3][col]
                if(word == 'XMAS'):
                    numberOfXmas += 1
            if(col > 2):
                word = matrix[row][col] + matrix[row][col-1] + matrix[row][col-2] + matrix[row][col-3]
                if(word == 'XMAS'):
                    numberOfXmas += 1
            if(numberOfColumns - col > 3):
                word = matrix[row][col] + matrix[row][col+1] + matrix[row][col+2] + matrix[row][col+3]
                if(word == 'XMAS'):
                    numberOfXmas += 1
            if(row > 2 and col > 2):
                word = matrix[row][col] + matrix[row-1][col-1] + matrix[row-2][col-2] + matrix[row-3][col-3]
                if(word == 'XMAS'):
                    numberOfXmas += 1 
            if(row > 2 and numberOfColumns - col > 3):
                word = matrix[row][col] + matrix[row-1][col+1] + matrix[row-2][col+2] + matrix[row-3][col+3]
                if(word == 'XMAS'):
                    numberOfXmas += 1                                
            if(numberOfRows - row > 3 and col > 2):
                word = matrix[row][col] + matrix[row+1][col-1] + matrix[row+2][col-2] + matrix[row+3][col-3]
                if(word == 'XMAS'):
                    numberOfXmas += 1 
            if(numberOfRows - row > 3 and numberOfColumns - col > 3):
                word = matrix[row][col] + matrix[row+1][col+1] + matrix[row+2][col+2] + matrix[row+3][col+3]
                if(word == 'XMAS'):
                    numberOfXmas += 1 

print(numberOfXmas)

#Copilot suggestion
# def check_word(matrix, row, col, dr, dc):
#     try:
#         return ''.join(matrix[row + i * dr][col + i * dc] for i in range(4)) == 'XMAS'
#     except IndexError:
#         return False

# numberOfXmas = sum(
#     check_word(matrix, row, col, dr, dc)
#     for row in range(numberOfRows)
#     for col in range(numberOfColumns)
#     for dr, dc in [(-1, 0), (1, 0), (0, -1), (0, 1), (-1, -1), (-1, 1), (1, -1), (1, 1)]
#     if matrix[row][col] == 'X'
# )
            