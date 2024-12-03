import re

# Original text
text = r"<long text here>"

# Regex pattern to match "don't()" followed by any characters and then "mul(x,y)"
pattern = r"don't\(\).*?do\(\)"

# Remove the matched patterns
cleaned_text = re.sub(pattern, '', text)
print("Cleaned text: ", cleaned_text)

# Regex pattern to match remaining "mul(x,y)"
pattern = r"mul\((\d{1,3}),(\d{1,3})\)"
matches = re.findall(pattern, cleaned_text)

# Calculate products and total sum
products = [int(x) * int(y) for x, y in matches]
total_sum = sum(products)

print("Products:", products)
print("Sum of all products:", total_sum)