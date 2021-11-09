using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests
{
    public class MakingDeposits
    {
        [Fact]
        public void MakingADepositIncreasesBalance()
        {
            //Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            //When
            account.Deposit(amountToDeposit);

            //Then
            Assert.Equal(
                openingBalance + amountToDeposit, account.GetBalance());
        }
    }
}
