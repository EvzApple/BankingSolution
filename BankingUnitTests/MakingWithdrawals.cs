using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests
{
    public class MakingWithdrawals
    {
        [Fact]
        public void MakingAWithdrawalDecreasesTheBalance()
        {
            //Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 100M;
            //When
            account.Withdraw(amountToWithdraw);
            //Then
            Assert.Equal(
                openingBalance - amountToWithdraw,
                account.GetBalance());
        }

        [Fact]
        public void Demo()
        { 
        
            var account1 = new BankAccount();
            var account2 = new BankAccount();

            account1.Withdraw(account1.GetBalance()); // What does this do?

            Assert.Equal(0, account1.GetBalance());
            Assert.Equal(5000M, account2.GetBalance());
        }
    }
}
