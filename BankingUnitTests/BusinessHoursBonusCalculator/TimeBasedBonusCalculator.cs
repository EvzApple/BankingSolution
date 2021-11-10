namespace BankingDomain
{
    public class TimeBasedBonusCalculator : ICalculateBonuses
    {
        private readonly IProvideTheBusinessClock _businessClock;

        public TimeBasedBonusCalculator(IProvideTheBusinessClock businessClock)
        {
            _businessClock = businessClock;
        }

        public decimal GetBonusForDeposit(decimal balance, decimal amountToDeposit)
        {
            if (_businessClock.IsDuringBusinessHours())
            {
                return amountToDeposit * .10m;
            }
            else
            {
                return 0;
            }
        }
    }
}