using ExCashRegister.PaymentMethod;
using ExCashRegister.PaymentMethod.ContactFull;
using ExCashRegister.PaymentMethod.ContactLess;
using ExCashRegister.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister
{
    class CashRegister
    {
        private bool safeClosed = true;
        private double currentValue;
        public List<Product> listOfProducts = new List<Product>();
        /// <summary>
        /// Creates cash register.
        /// </summary>
        public CashRegister()
        {

        }
        /// <summary>
        /// Returns the price of o product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public double ScanProduct(IProduct product)
        {
            return product.GetPrice();
        }
        /// <summary>
        /// Adds money to cash register by cash operation.
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool PayCash(double sum)
        {
            double initialValue = currentValue;

            this.safeClosed = false;
            Console.WriteLine("Safe open.");
            this.currentValue += sum;
            Console.WriteLine($"{sum} added to cash register.");
            this.safeClosed = true;
            Console.WriteLine("Safe closed.");

            if (initialValue == currentValue)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Creates a receipt for cash register.
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public Receipt CreateCashRegisterReceipt(double sum)
        {
            return new Receipt(sum);
        }
        /// <summary>
        /// Activates POS payment.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="sum"></param>
        /// <param name="paymentDevice"></param>
        /// <returns></returns>
        public bool PayWithPOS(POS pos, double sum, PaymentDevice paymentDevice)
        {
            double initialValue = this.currentValue;

            bool payment = pos.DetectPaymentMethod(pos, sum, paymentDevice);
            if (payment == true)
            {
                this.safeClosed = false;
                Console.WriteLine("Safe open.");
                this.currentValue += sum;
                Console.WriteLine($"{sum} added to cash register.");
                this.safeClosed = true;
                Console.WriteLine("Safe closed.");
            }
            if (initialValue == this.currentValue)
            {
                return false;
            }
            return true;

        }
        /// <summary>
        /// Returns POS device for payment.
        /// </summary>
        /// <returns></returns>
        public POS GetPOS()
        {
            return new POS();
        }
    }
}
namespace ExCashRegister.ReceiptExtension
{
    static class Print
    {
        /// <summary>
        /// Creates and prints cash register receipt.
        /// </summary>
        /// <param name="cashRegister"></param>
        /// <param name="sum"></param>
        public static void PrintReceipt(this CashRegister cashRegister, double sum)
        {
            Console.WriteLine($"{cashRegister.CreateCashRegisterReceipt(sum)}");
        }
    }

}

