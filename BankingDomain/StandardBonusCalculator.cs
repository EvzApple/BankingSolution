namespace BankingDomain
{
    public class StandardBonusCalculator
    {
        public decimal GetBonusForDeposit(decimal balance, decimal amountOfDeposit)
        {
            return balance >= 4000 ? amountOfDeposit *.1M : 0; 
            //could also do the if/else you were thinking
        }
    }
}