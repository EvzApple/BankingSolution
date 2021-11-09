namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000M;

        public decimal GetBalance()
        {
            return _balance;
            //return balance; //sliming --> you know that's not where it's gonna end up
            //             //but it works for now, then refactor and make more real
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            _balance -= amountToWithdraw;
        }

        public void Deposit(decimal amountToDeposit)
        {
            _balance += amountToDeposit;
        }
    }
}