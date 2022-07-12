using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister.PaymentMethod
{
    interface IContactLessPay
    {
        void TouchTheSensor();
        bool WithdrawMoneyContactLess(double sum, bool moneyWithdrawn);
    }
}
