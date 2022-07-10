using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister.PaymentMethod.ContactLess
{
    interface IContactLessPay
    {
        void TouchTheSensor();
        bool WithdrawMoney(double sum, bool moneyWithdrawn);
    }
    class ContactLessCard : IContactLessPay
    {
        /// <summary>
        /// Makes paying device available.
        /// </summary>
        public void TouchTheSensor()
        {
            this.availableForOperations = true;
        }
        /// <summary>
        /// Withdraws money from paying device.
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="moneyWithdrawn"></param>
        /// <returns></returns>
        public bool WithdrawMoney(double sum, bool moneyWithdrawn)
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
        public bool availableForOperations = false;
        private double currentValue;
        /// <summary>
        /// Creates Contactless Card
        /// </summary>
        /// <param name="currentValue"></param>
        public ContactLessCard(double currentValue)
        {
            this.currentValue = currentValue;
        }
        public override string ToString()
        {
            return "Contactless card";
        }
    }
}
