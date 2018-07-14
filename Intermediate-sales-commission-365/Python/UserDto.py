class UserDto: 
    revenue = {}
    expenses = {}
    commission = 0.062

    def __init__(self, name, revenue = {}, expenses = {}):
        self.name = name
        self.revenue = self.revenue.copy()
        self.expenses = self.expenses.copy()

    def add_revenue_item(self, item, value):
        self.revenue[item] = value
      
    def add_expenses_item(self, item, value):
        self.expenses[item] = value

    def get_commission(self):
        overall_profit = 0
        for key in self.revenue:
            overall_profit += max(float(self.revenue[key]) - float(self.expenses[key]), 0.0)
        
        return round(overall_profit * self.commission, 2)
