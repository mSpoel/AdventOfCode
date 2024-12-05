print('2024 - Day05 - Part 1')

def addRule(line):
    parts = line.split('|')
    key = int(parts[0])
    value = int(parts[1])

    if key not in rules:
        rules[key] = []
        
    rules[key].append(value)

rules = {}
pages = []
firstPart = True

with open("../../../Data/2024/Day05/input.txt", "r") as file:
    for line in file:
        if line.strip() == "":
            firstPart = False
            continue
        
        if firstPart:
            addRule(line)
        else:
            numbers = list(map(int, line.split(',')))
            pages.append(numbers)

validPages = pages.copy()
for page in pages:
    print('page: ', page)
    ruleViolated = False
    for i in range(1, len(page)):
        if ruleViolated:
            i = len(page)
            break
        number = page[i]
        print('number: ', number)
        if number in rules:
            rule = rules[number]
            print('rule: ', rule)
            for j in range(0, i):
                checkNumber = page[j]
                print('checkNumber: ', checkNumber)
                
                if checkNumber in rule:
                    ruleViolated = True
                    print('Rule violated')
                    validPages.remove(page)
                    break
        else:
            print(f"No rules found for {number}")

result = 0
for validPage in validPages:
    result += validPage[int((len(validPage)-1)/2)]

print('result: ', result)