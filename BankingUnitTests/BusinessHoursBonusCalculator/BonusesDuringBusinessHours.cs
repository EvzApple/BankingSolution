using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests.BusinessHoursBonusCalculator
{
    public class BonusesDuringBusinessHours
    {
        [Fact]
        public void BonusesAreAppliedDuringBusinessHours()
        {
            //ICalculateBonuses bonusCalculator = new TimeBasedBonusCalculator();

            var stubbedClock = new Mock<IProvideTheBusinessClock>();
            ICalculateBonuses bonusCalculator = new TimeBasedBonusCalculator(stubbedClock.Object);
            stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(true);

            var bonus = bonusCalculator.GetBonusForDeposit(5000, 100);

            Assert.Equal(10, bonus);
        }
        //[Fact]
        //public void BonusesAreNotGivenDuringBusinessHours()
        //{
        //    //ICalculateBonuses bonusCalculator = new TimeBasedBonusCalculator();

        //    var bonus = bonusCalculator.GetBonusForDeposit(5000, 100);

        //    Assert.Equal(10, bonus);
        //}
    }
}
