
// Base Account Class
class Account
{
    public int AccountNumber { get; private set; }
    public double Balance { get; protected set; }

    public Account(int accountNumber, double initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public virtual void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposit Successful! New Balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }

    public virtual void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawal Successful! New Balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount or insufficient balance.");
        }
    }

    public virtual void PrintAccountDetails()
    {
        Console.WriteLine($"Account Number: {AccountNumber}, Balance: {Balance}");
    }
}

// Savings Account (Derived from Account)
class SavingsAccount : Account
{
    public SavingsAccount(int accountNumber, double initialBalance)
        : base(accountNumber, initialBalance) { }
}

// Checking Account (Derived from Account)
class CheckingAccount : Account
{
    public CheckingAccount(int accountNumber, double initialBalance)
        : base(accountNumber, initialBalance) { }
}

// Bank Class to manage accounts
class Bank
{
    private List<Account> accounts = new List<Account>();

    public void AddAccount(Account account)
    {
        accounts.Add(account);
        Console.WriteLine($"Account added: {account.AccountNumber}");
    }

    public void RemoveAccount(int accountNumber)
    {
        Account account = GetAccount(accountNumber);
        if (account != null)
        {
            accounts.Remove(account);
            Console.WriteLine($"Account {accountNumber} removed.");
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    public Account GetAccount(int accountNumber)
    {
        return accounts.Find(acc => acc.AccountNumber == accountNumber);
    }

    public void PrintAllAccounts()
    {
        foreach (Account account in accounts)
        {
            account.PrintAccountDetails();
        }
    }
}

// Main Program with Menu
class Program2
{
    static Bank bank = new Bank();

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Banking System ---");
            Console.WriteLine("1. Create Savings Account");
            Console.WriteLine("2. Create Checking Account");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Print Account Details");
            Console.WriteLine("6. Print All Accounts");
            Console.WriteLine("7. Remove Account");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateAccount("Savings");
                    break;
                case 2:
                    CreateAccount("Checking");
                    break;
                case 3:
                    PerformTransaction("Deposit");
                    break;
                case 4:
                    PerformTransaction("Withdraw");
                    break;
                case 5:
                    PrintAccountDetails();
                    break;
                case 6:
                    bank.PrintAllAccounts();
                    break;
                case 7:
                    RemoveAccount();
                    break;
                case 8:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateAccount(string accountType)
    {
        Console.Write("Enter Account Number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter Initial Balance: ");
        double initialBalance = double.Parse(Console.ReadLine());

        if (accountType == "Savings")
        {
            bank.AddAccount(new SavingsAccount(accountNumber, initialBalance));
        }
        else if (accountType == "Checking")
        {
            bank.AddAccount(new CheckingAccount(accountNumber, initialBalance));
        }
    }

    static void PerformTransaction(string transactionType)
    {
        Console.Write("Enter Account Number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Account account = bank.GetAccount(accountNumber);

        if (account != null)
        {
            Console.Write("Enter Amount: ");
            double amount = double.Parse(Console.ReadLine());

            if (transactionType == "Deposit")
            {
                account.Deposit(amount);
            }
            else if (transactionType == "Withdraw")
            {
                account.Withdraw(amount);
            }
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static void PrintAccountDetails()
    {
        Console.Write("Enter Account Number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Account account = bank.GetAccount(accountNumber);

        if (account != null)
        {
            account.PrintAccountDetails();
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static void RemoveAccount()
    {
        Console.Write("Enter Account Number to remove: ");
        int accountNumber = int.Parse(Console.ReadLine());
        bank.RemoveAccount(accountNumber);
    }
}
