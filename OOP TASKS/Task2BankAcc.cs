using System;

class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal initialDeposit)
    {
        if (initialDeposit < 0)
            throw new ArgumentException("Initial deposit cannot be negative");

        Owner = owner;
        Balance = initialDeposit;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit must be positive");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdraw must be positive");

        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds");

        Balance -= amount;
    }

    public void PrintStatement()
    {
        Console.WriteLine($"{Owner} | Balance: {Balance}");
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount("Art", 100m);

        acc.Deposit(50m);
        acc.Withdraw(30m);

        try
        {
            acc.Withdraw(1000m);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        acc.PrintStatement();
    }
}
