using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests
{
    public class CreatingNewAccounts
    {
        [Fact]
        public void NewAccountsHaveCorrectOpeningBalance()
        {
            //WTCYWYH - "write the code you wish you had" --> Corey Haines
            //System Under Test (SUT) - BankAccount
            BankAccount account = new BankAccount();

            decimal openingBalance = account.GetBalance();

            Assert.Equal(5000M, openingBalance);
        }
    }
}
