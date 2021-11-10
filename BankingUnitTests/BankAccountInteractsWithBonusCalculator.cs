using BankingDomain;
using BankingUnitTests.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests
{
    public class BankAccountInteractsWithBonusCalculator
    {
        [Fact]
        public void UsesTheBonusCalculatorForDesposits()
        {
            var account = new BankAccount(new StubbedBonusCalculator());
            var openingBalance = account.GetBalance();
            var amountToDeposit = 123.23M; // weird made up thing.

            account.Deposit(amountToDeposit);

            Assert.Equal(
                openingBalance + amountToDeposit + 42.88M,
                account.GetBalance());
        }
    }
}
