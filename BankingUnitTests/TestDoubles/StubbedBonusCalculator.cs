using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingUnitTests.TestDoubles
{
    public class StubbedBonusCalculator : ICalculateBonuses
    {
        public decimal GetBonusForDeposit(decimal balance, decimal amountToDeposit)
        {
            return (balance == 5000M && amountToDeposit == 123.23M) ? 42.88m : 0;
        }
    }
}
