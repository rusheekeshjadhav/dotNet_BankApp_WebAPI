namespace BankApp_WebAPI.Models
{
    public class SavingAccount : BankAccount
    {
        public const double MinimumBalance = 500.0;
        public SavingAccount(string accountHolder, double balance, string accountType) : base(accountHolder, balance, accountType, MinimumBalance)
        { }
    }
}
