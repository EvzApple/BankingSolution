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
    public class MakingWithdrawals
    {
        private readonly BankAccount _account; //readonly has to be in a constructor and initialized
        private readonly decimal _openingBalance;
        public MakingWithdrawals()
        {
            _account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFed>().Object);
            _openingBalance = _account.GetBalance();
        }

        [Fact]
        public void MakingAWithdrawalDecreasesTheBalance()
        {
            //Given
            //var account = new BankAccount(new DummyBonusCalculator());
            //var openingBalance = account.GetBalance();
            var amountToWithdraw = 100M;
            //When
            _account.Withdraw(amountToWithdraw);
            //Then
            Assert.Equal(
                _openingBalance - amountToWithdraw,
                _account.GetBalance());
        }

        //withdrawing more than I have doesn't change the balance 
        [Fact]
        public void OverdraftDoesntChangeTheBalance()
        {
            //var account = new BankAccount(new DummyBonusCalculator());
            //var openingBalance = account.GetBalance();

            try
            {
                _account.Withdraw(_openingBalance + .01M);
            }
            catch (CannotOverdraftException)
            {
                //ignoring this for test
            }
            finally
            {
                Assert.Equal(_openingBalance, _account.GetBalance());
            }
        }

        [Fact]
        public void UsersCanWithdrawEntireBalance()
        {
            //var account = new BankAccount(new DummyBonusCalculator());
            //var openingBalance = account.GetBalance();

            _account.Withdraw(_openingBalance);

            Assert.Equal(0, _account.GetBalance());
        }

        //throw some kind of exception to let the consumer know it didn't work as expected
        [Fact]
        public void OverdraftThrows()
        {
            //var account = new BankAccount(new DummyBonusCalculator());
            //var openingBalance = account.GetBalance();

            Assert.Throws<CannotOverdraftException>(() => 
            {
                _account.Withdraw(_openingBalance + 1);
            });
        }

        //[Fact]
        //public void Demo()
        //{ 
        
        //    var account1 = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFed>().Object);
        //    var account2 = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFed>().Object);

        //    account1.Withdraw(account1.GetBalance()); // What does this do?

        //    Assert.Equal(0, account1.GetBalance());
        //    Assert.Equal(5000M, account2.GetBalance());
        
    }
}
