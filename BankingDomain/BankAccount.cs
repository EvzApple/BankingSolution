namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000M;
        private ICalculateBonuses _bonusCalculator;

        public BankAccount(ICalculateBonuses bonusCalculator)
        {
            _bonusCalculator = bonusCalculator;
        }

        public decimal GetBalance()
        {
            return _balance;
            //return balance; //sliming --> you know that's not where it's gonna end up
            //             //but it works for now, then refactor and make more real
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _balance)
            {
                throw new CannotOverdraftException();
            }
            else
            {
                _balance -= amountToWithdraw;
            }
        }

        public void Deposit(decimal amountToDeposit)
        {
            //var bonusCalculator = new StandardBonusCalculator();
            decimal bonus = _bonusCalculator.GetBonusForDeposit(_balance, amountToDeposit);

            _balance += amountToDeposit + bonus;
        }
    }
}