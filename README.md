# Command-Line Expense Tracker

A simple command-line application to help users manage their finances. The application allows users to add, update, delete, and view expenses. It also provides summaries and budgeting tools.

## Features

### Core Features
- **Add Expense**: Users can add an expense with a description and amount.
- **Update Expense**: Users can update an existing expense.
- **Delete Expense**: Users can delete an expense.
- **View All Expenses**: Users can view a list of all recorded expenses.
- **Expense Summary**:
  - View total expenses.
  - View summary of expenses for a specific month (current year only).

### Additional Features
- **Expense Categories**:
  - Assign categories to expenses (e.g., Food, Transport, Bills).
  - Filter expenses by category.
- **Monthly Budget**:
  - Set a budget for each month.
  - Receive a warning when expenses exceed the monthly budget.
- **Export to CSV**:
  - Export all expense data to a CSV file for external use or backup.


## EXPECTED OUTPUT

```yaml
$ expense-tracker add --description "Lunch" --amount 20
# Expense added successfully (ID: 1)

$ expense-tracker add --description "Dinner" --amount 10
# Expense added successfully (ID: 2)

$ expense-tracker list
# ID  Date       Description  Amount
# 1   2024-08-06  Lunch        $20
# 2   2024-08-06  Dinner       $10

$ expense-tracker summary
# Total expenses: $30

$ expense-tracker delete --id 2
# Expense deleted successfully

$ expense-tracker summary
# Total expenses: $20

$ expense-tracker summary --month 8
# Total expenses for August: $20
```