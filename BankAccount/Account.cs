using System.Globalization;

namespace BankAccount;

public class Account
{
    private static readonly int[] SortCodeDigits = { 0, 1, 3, 4, 6, 7 };
    private decimal _balance;
    private string _accountHolder = "John Doe";
    private string _sortCode = "00-00-00";
    public string SortCode
    {
        get => _sortCode;
        set
        {
            var newSortCode = "";
            for (var i = 0; i < 8; i++)
            {
                if (SortCodeDigits.Contains(i))
                {
                    newSortCode += value[i];
                    continue;
                }
                newSortCode += "-";
            }
                
            _sortCode = newSortCode;
        }
    }
        
    public string AccountHolder { get => _accountHolder; set => _accountHolder = value; }

    public string Balance
    {
        get => "£"+_balance.ToString(CultureInfo.CurrentCulture); 
        set => _balance = Convert.ToDecimal(value);
    }

    public bool Withdraw(decimal amount)
    {
        if (_balance - amount < 0)
        {
            return false;
        }
        _balance -= amount;
        return true;
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
    }

    public void Display()
    {
        Console.WriteLine($"Account holder: {AccountHolder}\nSort code: {SortCode}\nBalance: {Balance}");
    }
        
    public Account(string accountHolder, string sortCode)
    {
        AccountHolder = accountHolder;
        SortCode = sortCode;
    }
}