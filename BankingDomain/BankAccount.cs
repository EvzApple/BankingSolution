namespace BankingDomain
{
    public enum BankAccountType {  Standard, Gold, Platinum } //enum = enumerated constant = range of accepted values
    public class BankAccount
    {
        private decimal _balance = 5000M;
        public BankAccountType AccountType = BankAccountType.Standard;

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
            if (this.AccountType == BankAccountType.Gold)
            {
                _balance += amountToDeposit * 1.10M;
            }
            else
            {
                _balance += amountToDeposit;
            }
        }
    }
}