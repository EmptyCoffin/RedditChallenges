using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommissionCalculatorCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("ChallengeInput.txt").Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

            var indexOfReveneStart = lines.IndexOf("Revenue");
            var indexOfExpensesStart = lines.IndexOf("Expenses");

            List<UserDto> userList  = new List<UserDto>();

            // get users
            foreach(var user in lines[indexOfReveneStart + 1].Split((char[]) null, StringSplitOptions.RemoveEmptyEntries)) 
            {
                userList.Add(new UserDto(user));
            }

            // add revenue for user
            foreach(var item in lines.GetRange(indexOfReveneStart + 2, (indexOfExpensesStart - (indexOfReveneStart + 2)))) 
            {
                var itemInfo = item.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries); 
                var userIndex = 1;
                userList.ForEach(user => {
                    user.Revenue[itemInfo[0]] = Double.Parse(itemInfo[userIndex]);
                    userIndex++;
                });
            }

            // add expenses for user
            foreach(var item in lines.GetRange(indexOfExpensesStart + 2, lines.Count - (indexOfExpensesStart + 2))) 
            {
                var itemInfo = item.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries); 
                var userIndex = 1;
                userList.ForEach(user => {
                    user.Expenses[itemInfo[0]] = Double.Parse(itemInfo[userIndex]);
                    userIndex++;
                });
            }

            userList.ForEach(user => Console.WriteLine($"{user.Name}, Commission: {user.getCommission()}"));

        }
    }
}
