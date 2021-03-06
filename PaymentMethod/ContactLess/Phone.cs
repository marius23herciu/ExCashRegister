using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister.PaymentMethod.ContactLess
{

    class Phone : PaymentDevice, IContactLessPay
    {
        public void TouchTheSensor()
        {
            this.availableForOperations = true;
        }
        public bool WithdrawMoneyContactLess(double sum, bool moneyWithdrawn)
        {
            if (this.availableForOperations == true && sum <= this.currentValue)
            {
                this.currentValue -= sum;
                this.availableForOperations = false;
                return moneyWithdrawn = true;
            }
            Console.WriteLine("Payment canceled!");
            this.availableForOperations = false;
            return moneyWithdrawn = false;
        }
        /// <summary>
        /// Creates contactless phone.
        /// </summary>
        /// <param name="currentValue"></param>
        public Phone(double currentValue) : base(currentValue)
        {

        }
        public override string ToString()
        {
            return "Contactless phone";
        }
    }
}
