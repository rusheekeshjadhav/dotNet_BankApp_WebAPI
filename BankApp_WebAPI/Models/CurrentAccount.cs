namespace BankApp_WebAPI.Models
{
    public class CurrentAccount : BankAccount
    {
        public const double MinimumBalance = 1000.0;

        public CurrentAccount(string accountHolder, double balance, string accountType) : base(accountHolder, balance, accountType, MinimumBalance)
        { }
    }
}
