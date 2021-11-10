namespace BankingDomain
{
    public interface IProvideTheBusinessClock
    {
        bool IsDuringBusinessHours();
        public void Between9And5IsOpen();
        public void OtherwiseClosed();
    }
}