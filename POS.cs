using ExCashRegister.PaymentMethod;
using ExCashRegister.PaymentMethod.ContactFull;
using ExCashRegister.PaymentMethod.ContactLess;

namespace ExCashRegister
{
    class POS
    {
        public POS()
        {

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
    }
}
