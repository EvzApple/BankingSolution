namespace BankingDomain
{
    public interface INotifyTheFed
    {
        void NotifyOfWithdraw(BankAccount bankAccount, decimal amountToWithdraw);
    }
}