using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister.PaymentMethod.ContactFull
{
    class ClassicCard : IContactFullPay
    {
        /// <summary>
        /// Makes card available for operations.
        /// </summary>
        public void InsertCard()
        {
            availableForOperations = true;
        }
        /// <summary>
        /// Withdraws money from card.
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="moneyWithdrawn"></param>
        /// <returns></returns>
        public bool WithdrawMoneyContactFull(double sum, bool moneyWithdrawn)
        {
            if (this.availableForOperations == true && sum <= this.currentValue)
            {
                this.currentValue -= sum;
                return moneyWithdrawn = true;
            }
            Console.WriteLine("Payment canceled!");
            return moneyWithdrawn = false;
        }
        /// <summary>
        /// Makes card unavailable for operations.
        /// </summary>
        public void ExtractCard()
        {
            this.availableForOperations = false;
        }
        public bool availableForOperations = false;
        public double currentValue;
        /// <summary>
        /// Creates contactfull card.
        /// </summary>
        /// <param name="currentValue"></param>
        public ClassicCard(double currentValue)
        {
            this.currentValue = currentValue;
        }
        public override string ToString()
        {
            return "Contactfull card";
        }
    }
}
