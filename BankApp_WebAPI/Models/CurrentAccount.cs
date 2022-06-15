namespace BankApp_WebAPI.Models
{
    public class CurrentAccount : BankAccount
    {
        public double MinimumBalance { get; set; } = 1000.0;

        CurrentAccount(string accountHolder, double balance, string accountType) : base(accountHolder, balance, accountType)
        { }
    }
}
