namespace BankApp_WebAPI.Models
{
    public class AccountFactory
    {
        public BankAccount getBankAccount(BankAccount account)
        {
            if (account.AccountType == "Current")
                return new CurrentAccount(account.AccountHolder, account.Balance, account.AccountType);
            else
                return new SavingAccount(account.AccountHolder, account.Balance, account.AccountType); ;
        }
    }
}
