# Command-Line Expense Tracker

A simple command-line application to help users manage their finances. The application allows users to add, update, delete, and view expenses. It also provides summaries and basic budgeting tools.

---

## Quick Start

Follow these steps to get the project running locally.

### Prerequisites
- .NET SDK (6.0 or later)
- Git
- A terminal or command prompt

Verify installation:
```bash
dotnet --version
git --version
```
### Clone Repo

```bash
git clone https://github.com/your-username/expense-tracker.git
cd expense-tracker
```

### Build Repo

```bash
dotnet restore
dotnet build
```

### Basic Usage

### Commands follow this general structure:

```bash
expense-tracker <command> [options]
```
### Add an Expense

```bash
expense-tracker add --description "Groceries" --amount 250 --category Food
```

### Update an Expense

```bash
expense-tracker update --id 1 --amount 300
```
### Delete an Expense
```bash
expense-tracker delete --id 1
```

### View All Expenses

```bash
expense-tracker list
```
### View Expense Summary
```bash
expense-tracker summary
expense-tracker summary --month Jan
expense-tracker summary --month 2025-01
```