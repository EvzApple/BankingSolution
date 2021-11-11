using BankingDomain;
using BankingUnitTests.TestDoubles;
using Moq;
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
            //Given
            var stubbedBonusCalculator = new Mock<ICalculateBonuses>();
            //mock reads interface and generates new "mock" class and object for this test,
            //and implements interface
            var account = new BankAccount(stubbedBonusCalculator.Object, new Mock<INotifyTheFed>().Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 123.23M; // weird made up thing.
            stubbedBonusCalculator.Setup(b => 
                b.GetBonusForDeposit(openingBalance, amountToDeposit)).Returns(42.88M);

            //When
            account.Deposit(amountToDeposit);


            //Then
            Assert.Equal(
                openingBalance + amountToDeposit + 42.88M,
                account.GetBalance());
        }
    }
}
