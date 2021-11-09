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
        public void DepositsGetsBonus()
        {
            var account = new GoldAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(
                openingBalance + amountToDeposit + 10M, 
                account.GetBalance());
        }
    }
}
