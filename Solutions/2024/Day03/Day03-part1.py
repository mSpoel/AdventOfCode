import re

pattern = r"mul\((\d{1,3}),(\d{1,3})\)"
text = "<input long string here>"
matches = re.findall(pattern, text)
products = [int(x) * int(y) for x, y in matches]
total_sum = sum(products)

print("Products:", products)
print("Sum of all products:", total_sum)