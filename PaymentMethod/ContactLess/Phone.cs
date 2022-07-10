using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister.PaymentMethod.ContactLess
{

    class Phone : ContactLessCard, IContactLessPay
    {
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
