using ExCashRegister.PaymentMethod.ContactFull;
using ExCashRegister.PaymentMethod.ContactLess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister
{
    class Receipt
    {
        public string description;
        public double price;
        /// <summary>
        /// Creates cash register receipt.
        /// </summary>
        /// <param name="price"></param>
        public Receipt(double price)
        {
            this.description = "Total amount";
            this.price = price;
        }
        public override string ToString()
        {
            return $"{description} {price}";
        }
    }
    class PosReceipt : Receipt
    {
        /// <summary>
        /// Creates  POS receipt.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="classicCard"></param>
        public PosReceipt(double price, ClassicCard classicCard) : base(price)
        {
            this.description = $"paied with { classicCard }";
        }
        /// <summary>
        /// Creates  POS receipt.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="contactLessCard"></param>
        public PosReceipt(double price, ContactLessCard contactLessCard) : base(price)
        {
            this.description = $"paied with {contactLessCard}";
        }
        public override string ToString()
        {
            return $"{price} {description}";
        }
    }
}
