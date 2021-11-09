using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests
{
    public class GoldAccountsGetBonus
    {
        [Fact]
        public void BonusOnDeposits()
        {
            //Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;
            account.AccountType = BankAccountType.Gold;

            //When
            account.Deposit(amountToDeposit);

            //Then
            Assert.Equal(
                openingBalance + amountToDeposit + 10M,
                account.GetBalance());
        }
    }
}
