using System;
using System.Collections.Generic;

namespace CommissionCalculatorCSharp
{
    public class UserDto
    {
        private double _commission = 0.062;
        public string Name {get;set;}
        public Dictionary<string, double> Revenue {get;set;}
        public Dictionary<string, double> Expenses {get;set;}

        public UserDto(string name)
        {
            Name = name;
            Revenue = new Dictionary<string, double>();
            Expenses = new Dictionary<string, double>();
        }

        public double getCommission() 
        {
            double overallProfit = 0.0;

            foreach(var item in Revenue)
            {
                overallProfit += Math.Max(Revenue[item.Key] - Expenses[item.Key], 0);
            }

            return Math.Round(overallProfit * _commission, 2);
        }
    }
}