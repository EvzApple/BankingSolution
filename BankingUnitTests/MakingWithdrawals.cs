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
    public class MakingWithdrawals
    {
        [Fact]
        public void MakingAWithdrawalDecreasesTheBalance()
        {
            //Given
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 100M;
            //When
            account.Withdraw(amountToWithdraw);
            //Then
            Assert.Equal(
                openingBalance - amountToWithdraw,
                account.GetBalance());
        }

        //withdrawing more than I have doesn't change the balance 
        [Fact]
        public void OverdraftDoesntChangeTheBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(openingBalance + .01M);
            }
            catch (CannotOverdraftException)
            {
                //ignoring this for test
            }
            finally
            {
                Assert.Equal(openingBalance, account.GetBalance());
            }
        }

        [Fact]
        public void UsersCanWithdrawEntireBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();

            account.Withdraw(openingBalance);

            Assert.Equal(0, account.GetBalance());
        }

        //throw some kind of exception to let the consumer know it didn't work as expected
        [Fact]
        public void OverdraftThrows()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();

            Assert.Throws<CannotOverdraftException>(() => 
            {
                account.Withdraw(openingBalance + 1);
            });
        }

        [Fact]
        public void Demo()
        { 
        
            var account1 = new BankAccount(new DummyBonusCalculator());
            var account2 = new BankAccount(new DummyBonusCalculator());

            account1.Withdraw(account1.GetBalance()); // What does this do?

            Assert.Equal(0, account1.GetBalance());
            Assert.Equal(5000M, account2.GetBalance());
        }
    }
}
