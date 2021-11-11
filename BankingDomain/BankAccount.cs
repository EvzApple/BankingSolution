namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 5000M;
        private readonly ICalculateBonuses _bonusCalculator;
        private readonly INotifyTheFed _fedNotifier;

        public BankAccount(ICalculateBonuses bonusCalculator, INotifyTheFed fedNotifier)
        {
            _bonusCalculator = bonusCalculator;
            _fedNotifier = fedNotifier; 

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
                //Write the code you wish you had
                _fedNotifier.NotifyOfWithdraw(this, amountToWithdraw); //"this" on this particular created instance
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