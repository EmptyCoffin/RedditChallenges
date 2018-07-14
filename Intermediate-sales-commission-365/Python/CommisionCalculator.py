from UserDto import UserDto

def add_item_to_hash(index, type, users):
   for lineItem in data[index:]:
    item = lineItem.split()
    if not item:
        break

    for index, user in enumerate(users):
        if type == "Revenue":
            user.add_revenue_item(item[0], item[index + 1]) 
        else:
            user.add_expenses_item(item[0], item[index + 1])

data = open('ChallengeInput.txt').read().splitlines()
indexOfRevenueStart = data.index('Revenue')
indexOfExpensesStart = data.index('Expenses')

userString = data[indexOfRevenueStart + 2]
newUsers = userString.split()
users = []

""" Create Users """
for newUser in newUsers:
    users.append(UserDto(newUser))

""" Add Revenue """
add_item_to_hash(indexOfRevenueStart + 3, "Revenue", users)

""" Add Expenses """
add_item_to_hash(indexOfExpensesStart + 3, "Expenses", users)

""" print results """
for user in users:
    print(f"{user.name}, Commission: {user.get_commission()}")