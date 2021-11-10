using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingUnitTests.TestDoubles
{
    public class DummyBonusCalculator : ICalculateBonuses
    {
        public decimal GetBonusForDeposit(decimal balance, decimal amountToDeposit)
        {
            return 0;
        }
    }
}
