using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister.PaymentMethod
{
    interface IContactFullPay
    {
        void InsertCard();
        bool WithdrawMoneyContactFull(double sum, bool moneyWithdrawn);
        void ExtractCard();
    }
}
