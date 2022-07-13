using ExCashRegister.PaymentMethod;
using ExCashRegister.PaymentMethod.ContactFull;
using ExCashRegister.PaymentMethod.ContactLess;
using System;

namespace ExCashRegister
{
    class POS
    {
        public POS()
        {

        }
        /// <summary>
        /// Finds out what type of payment device is used points to payment the right payment method.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="sum"></param>
        /// <param name="paymentDevice"></param>
        /// <returns></returns>
        public bool DetectPaymentMethod(POS pos, double sum, PaymentDevice paymentDevice)
        {
            if (paymentDevice is IContactLessPay)
            {
                if (paymentDevice is Phone)
                {
                    Phone phone = (Phone)paymentDevice;
                    bool payment = pos.Pay(sum, phone);
                    return payment;
                }
                if (paymentDevice is ContactLessCard)
                {
                    ContactLessCard contactLessCard = (ContactLessCard)paymentDevice;
                    bool moneyWithdrawn = false;
                    contactLessCard.TouchTheSensor();
                    moneyWithdrawn = contactLessCard.WithdrawMoneyContactLess(sum, moneyWithdrawn);
                    return moneyWithdrawn;
                }
            }
            else if (paymentDevice is IContactFullPay)
            {
                ClassicCard classicCard = (ClassicCard)paymentDevice;
                bool payment = pos.Pay(sum, classicCard);
                return payment;
            }
            return false;
        }

        /// <summary>
        /// Pay with contactless device.
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="contactLessPay"></param>
        /// <returns></returns>
        public bool Pay(double sum, IContactLessPay contactLessPay)
        {
            bool moneyWithdrawn = false;
            contactLessPay.TouchTheSensor();
            moneyWithdrawn = contactLessPay.WithdrawMoneyContactLess(sum, moneyWithdrawn);
            return moneyWithdrawn;
        }
        /// <summary>
        /// Pay with contactfull card.
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="contactFullPay"></param>
        /// <returns></returns>
        public bool Pay(double sum, IContactFullPay contactFullPay)
        {
            bool moneyWithdrawn = false;
            contactFullPay.InsertCard();
            moneyWithdrawn = contactFullPay.WithdrawMoneyContactFull(sum, moneyWithdrawn);
            contactFullPay.ExtractCard();
            return moneyWithdrawn;
        }

        /// <summary>
        /// Creates a receipt for POS.
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="classicCard"></param>
        /// <returns></returns>
        public PosReceipt CreatePosReceipt(double sum, PaymentDevice paymentDevice)
        {
            return new PosReceipt(sum, paymentDevice);
        }
    }
}
namespace ExCashRegister.ReceiptPOSExtension
{
    static class Print
    {
        /// <summary>
        /// Creates and prints POS receipt.
        /// </summary>
        /// <param name="cashRegister"></param>
        /// <param name="sum"></param>
        /// <param name="classicCard"></param>
        public static void PrintPOSReceipt(this POS pos, double sum, PaymentDevice paymentDevice)
        {
            Console.WriteLine(pos.CreatePosReceipt(sum, paymentDevice));
        }
    }

}
