namespace BankApp_WebAPI.Models
{
    public delegate void DepositMoney(double amount);
    public delegate void WithDrawMoney(double amount);

    public class TransactionEvent
    {
        public event DepositMoney depositMoney;
        public event WithDrawMoney withdrawMoney;

        public void onDepositMoney(double amount)
        {
            if (depositMoney != null)
                depositMoney(amount);
        }

        public void onWithdrawMoney(double amount)
        {
            if (withdrawMoney != null)
                withdrawMoney(amount);
        }

    }
}
