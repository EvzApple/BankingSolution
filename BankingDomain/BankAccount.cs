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

        public virtual void Deposit(decimal amountToDeposit) //add virtual to make change to method in child class
        {
            _balance += amountToDeposit;
        }
    }
}