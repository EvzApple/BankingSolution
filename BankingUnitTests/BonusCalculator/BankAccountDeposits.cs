using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests.BonusCalculator
{
    public class BankAccountDeposits
    {
        [Fact]
        public void DepositsBelowThresholdGetNoBonus()
        {
            StandardBonusCalculator bonusCalculator = new StandardBonusCalculator();
            decimal balance = 3999.99M;
            decimal amountOfDeposit = 100;

            decimal bonus = bonusCalculator.GetBonusForDeposit(balance, amountOfDeposit);

            Assert.Equal(0, bonus);
        }
        [Theory]
        [InlineData(100, 10)]
        [InlineData(200, 20)]
        public void DepositsAtThresholdGetBonus(decimal amountOfDeposit, decimal expectedBonus)
        {
            StandardBonusCalculator bonusCalculator = new StandardBonusCalculator();
            decimal balance = 4000M;

            decimal bonus = bonusCalculator.GetBonusForDeposit(balance, amountOfDeposit);

            Assert.Equal(expectedBonus, bonus);
        }
        [Theory]
        [InlineData(4000, 100, 10)]
        [InlineData(4001, 200, 20)]
        [InlineData(10000, 100, 10)]
        public void DepositsOverThresholdGetBonus(decimal balance, decimal amountOfDeposit, decimal expectedBonus)
        {
            StandardBonusCalculator bonusCalculator = new StandardBonusCalculator();
            

            decimal bonus = bonusCalculator.GetBonusForDeposit(balance, amountOfDeposit);

            Assert.Equal(expectedBonus, bonus);
        }
    }
}
