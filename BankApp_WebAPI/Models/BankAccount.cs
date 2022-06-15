namespace BankApp_WebAPI.Models
{
    public class BankAccount: AbstractAccount
    {
        public int Id { get; set; }
        public string AccountHolder { get; set; }
        public double Balance { get; set; }
        public string AccountType { get; set; }

        public double MinimumBalance { get; set; }

        public TransactionEvent trans = new TransactionEvent();

        public BankAccount()
        {
            trans.depositMoney += this.deposit;
            trans.withdrawMoney += this.withdraw;
        }

        public BankAccount(string accountHolder, double balance, string accountType, double minimumBalance)
        {
            AccountHolder = accountHolder;
            Balance = balance;
            AccountType = accountType;
            MinimumBalance = minimumBalance;
        }

        public void deposit(double amount)
        {
            Balance = Balance + amount;
        }

        public void withdraw(double amount)
        {
            if (Balance > amount)
                Balance = Balance - amount;
            else
                throw new Exception("Insufficient Balance !!!");
        }
    }
}
