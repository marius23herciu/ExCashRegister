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
        /// Creates a receipt for POS.
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="classicCard"></param>
        /// <returns></returns>
        public PosReceipt CreatePosReceipt(double sum, ClassicCard classicCard)
        {
            return new PosReceipt(sum, classicCard);
        }
        /// <summary>
        /// Creates a receipt for POS.
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="contactLessCard"></param>
        /// <returns></returns>
        public PosReceipt CreatePosReceipt(double sum, Phone phone)
        {
            return new PosReceipt(sum, phone);
        }
        /// <summary>
        ///  Adds money to cash register by contactfull payment.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="sum"></param>
        /// <param name="classicCard"></param>
        /// <returns></returns>
        public bool PayWithPOS(POS pos, double sum, ClassicCard classicCard)
        {
            double initialValue = currentValue;
            bool payment = pos.Pay(sum, classicCard);
            if (payment == true)
            {
                this.safeClosed = false;
                Console.WriteLine("Safe open.");
                this.currentValue += sum;
                Console.WriteLine($"{sum} added to cash register.");
                this.safeClosed = true;
                Console.WriteLine("Safe closed.");
            }
            if (initialValue == currentValue)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        ///  Adds money to cash register by cantactless payment.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="sum"></param>
        /// <param name="contactLessCard"></param>
        /// <returns></returns>
        public bool PayWithPOS(POS pos, double sum, Phone phone)
        {
            double initialValue = currentValue;
            bool payment = pos.Pay(sum, phone);
            if (payment == true)
            {
                this.safeClosed = false;
                Console.WriteLine("Safe open.");
                this.currentValue += sum;
                Console.WriteLine($"{sum} added to cash register.");
                this.safeClosed = true;
                Console.WriteLine("Safe closed.");
            }
            if (initialValue == currentValue)
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
        /// <summary>
        /// Creates and prints POS receipt.
        /// </summary>
        /// <param name="cashRegister"></param>
        /// <param name="sum"></param>
        /// <param name="classicCard"></param>
        public static void PrintPOSReceipt(this CashRegister cashRegister, double sum, ClassicCard classicCard)
        {
            Console.WriteLine(cashRegister.CreatePosReceipt(sum, classicCard));
        }
        /// <summary>
        /// Creates and prints POS receipt.
        /// </summary>
        /// <param name="cashRegister"></param>
        /// <param name="sum"></param>
        /// <param name="contactLessCard"></param>
        public static void PrintPOSReceipt(this CashRegister cashRegister, double sum, Phone phone)
        {
            Console.WriteLine(cashRegister.CreatePosReceipt(sum, phone));
        }

    }

}

