using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDomain
{
    public class GoldAccount : BankAccount //gold account is a kind of bank account
    {
        public override void Deposit(decimal amountToDeposit)
        {
            base.Deposit(amountToDeposit * 1.1M);
        }
    }
}
