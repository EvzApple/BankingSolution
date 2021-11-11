using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests
{
    public class BankAccountInteractsWithFedNotifier
    {
        [Fact]
        public void NotifiesTheFedOfWithdrawals()
        {
            // Given
            var fedNotifierMock = new Mock<INotifyTheFed>();
            var account = new BankAccount(new Mock<ICalculateBonuses>().Object, fedNotifierMock.Object);

            // When
            account.Withdraw(42.38M);

            // Then
            fedNotifierMock.Verify(m => m.NotifyOfWithdraw(account, 42.38M));
        }
    }
}
