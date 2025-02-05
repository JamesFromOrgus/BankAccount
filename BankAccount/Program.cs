
namespace BankAccount
{
    internal static class Program
    {
        private static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }
        
        public static void Main()
        {
            var name = GetInput("Enter account holder name: ");
            var code = GetInput("Enter sort code: ");
            var myAccount = new Account(name, code);
            myAccount.Display();
            myAccount.Deposit(1000); // Balance -> £1000
            myAccount.Display();
            myAccount.Withdraw(400); // Balance -> £600
            myAccount.Display();
            myAccount.Withdraw(601); // Should fail since this will cause balance to go below zero
            myAccount.Display();
        }
    }
}


