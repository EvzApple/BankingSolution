using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingUnitTests.TestDoubles
{
    //Dummies are test doubles that are there just so you don't get a null 
    //reference when running your test. 
    //They are used when you SUT has a dependency, but that dependency shouldn't
    //have any influence on that particular test. 
    public class DummyBonusCalculator : ICalculateBonuses
    {
        public decimal GetBonusForDeposit(decimal balance, decimal amountToDeposit)
        {
            return 0;
        }
    }
}
