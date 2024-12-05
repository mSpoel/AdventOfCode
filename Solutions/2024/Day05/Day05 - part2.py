print('2024 - Day05 - Part 2')

def addRule(line):
    parts = line.split('|')
    key = int(parts[0])
    value = int(parts[1])

    if key not in rules:
        rules[key] = []
        
    rules[key].append(value)

def isValid(page):
    ruleViolated = False
    for i in range(1, len(page)):
        if ruleViolated:
            i = len(page)
            break
        number = page[i]
        if number in rules:
            rule = rules[number]
            for j in range(0, i):
                checkNumber = page[j]
                
                if checkNumber in rule:
                    ruleViolated = True
        else:
            print(f"No rules found for {number}")

    return not ruleViolated

def correctPage(page):
    for i in range(1, len(page)):
        number = page[i]
        if number in rules:
            rule = rules[number]
            for j in range(0, i):
                checkNumber = page[j]
                
                if checkNumber in rule:
                    page[i] = checkNumber
                    page[j] = number
                    return page
        else:
            print(f"No rules found for {number}")

    return page


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

toBeCorrectedPages = pages.copy()
for page in pages:
    if isValid(page):
        toBeCorrectedPages.remove(page)

correctedPages = []
for toBeCorrectedPage in toBeCorrectedPages:
    print('Correcting: ', toBeCorrectedPage)
    while(not isValid(toBeCorrectedPage)):
        toBeCorrectedPage = correctPage(toBeCorrectedPage)
        print('Corrected page: ', toBeCorrectedPage)
    
    correctedPages.append(toBeCorrectedPage)

result = 0
for validPage in correctedPages:
    result += validPage[int((len(validPage)-1)/2)]

print('result: ', result)