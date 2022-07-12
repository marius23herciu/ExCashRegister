using ExCashRegister.PaymentMethod.ContactFull;
using ExCashRegister.PaymentMethod.ContactLess;
using ExCashRegister.ReceiptExtension;
using System;

namespace ExCashRegister
{
    class Program
    {
        static void Main(string[] args)
        {

            var product = new Products.Product("charger", 50);
            var product1 = new Products.Product("smartphone", 2000);
            var product2 = new Products.Product("TV", 3000);
            var product3 = new Products.Product("oven", 1500);
            var product4 = new Products.Product("USB cable", 20);

            
            var cashRegister = new CashRegister();

            bool sale = cashRegister.PayCash(cashRegister.ScanProduct(product3));
            if (sale == true)
            {
                cashRegister.PrintReceipt(cashRegister.ScanProduct(product3));
            }


            var classicCard = new ClassicCard(30000);
            var contactLessCard = new ContactLessCard(15000);
            var phone = new Phone(20000);


            sale = cashRegister.PayWithPOS(cashRegister.GetPOS(), cashRegister.ScanProduct(product3), classicCard);
            if (sale == true)
            {
                cashRegister.PrintPOSReceipt(cashRegister.ScanProduct(product3), classicCard);
                cashRegister.PrintReceipt(cashRegister.ScanProduct(product3));
            }
            sale = cashRegister.PayWithPOS(cashRegister.GetPOS(), cashRegister.ScanProduct(product1), contactLessCard);
            if (sale == true)
            {
                cashRegister.PrintPOSReceipt(cashRegister.ScanProduct(product1), contactLessCard);
                cashRegister.PrintReceipt(cashRegister.ScanProduct(product1));
            }
            sale = cashRegister.PayWithPOS(cashRegister.GetPOS(), cashRegister.ScanProduct(product2), phone);
            if (sale == true)
            {
                cashRegister.PrintPOSReceipt(cashRegister.ScanProduct(product2), phone);
                cashRegister.PrintReceipt(cashRegister.ScanProduct(product2));
            }

            cashRegister.PayWithPOS(cashRegister.GetPOS(), 50000, classicCard);
            cashRegister.PayWithPOS(cashRegister.GetPOS(), 50000, contactLessCard);


            cashRegister.listOfProducts.Add(product);
            cashRegister.listOfProducts.Add(product1);
            cashRegister.listOfProducts.Add(product2);
            cashRegister.listOfProducts.Add(product3);
            cashRegister.listOfProducts.Add(product4);
            ////////////////////    CASH REGISTER MENU   //////////////////
            ///
            Console.WriteLine("Add products to shopping basket?   y/n");
            char yesOrNo = Console.ReadKey().KeyChar;
            double totalAmount = 0;
            int answer;
            Console.WriteLine();
            while (yesOrNo == 'y')
            {
                Console.WriteLine("List of products:");
                for (int i = 0; i < cashRegister.listOfProducts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {cashRegister.listOfProducts[i]}");
                }
                Console.WriteLine("Insert the number of the product:");
                answer = int.Parse(Console.ReadLine());
                Console.WriteLine($"How many {cashRegister.listOfProducts[answer - 1].nameOfProduct} do you want to add?");
                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    totalAmount += cashRegister.ScanProduct(cashRegister.listOfProducts[answer - 1]);
                }
                Console.WriteLine("Continue adding products to shopping basket?   y/n");
                yesOrNo = Console.ReadKey().KeyChar;
            }
            Console.WriteLine();
            if (totalAmount > 0)
            {
                Console.WriteLine("1)Cash or 2)Card?");
                answer = int.Parse(Console.ReadLine());
                if (answer == 1)
                {
                    sale = cashRegister.PayCash(totalAmount);
                    if (sale == true)
                    {
                        cashRegister.PrintReceipt(totalAmount);
                    }
                }
                if (answer == 2)
                {
                    Console.WriteLine("1)Contacfull, 2)ContactLess card or 3)Contactless phone");
                    answer = int.Parse(Console.ReadLine());
                    if (answer == 1)
                    {
                        sale = cashRegister.PayWithPOS(cashRegister.GetPOS(), totalAmount, classicCard);
                        if (sale == true)
                        {
                            cashRegister.PrintPOSReceipt(totalAmount, classicCard);
                            cashRegister.PrintReceipt(totalAmount);
                        }
                    }
                    if (answer == 2)
                    {
                        sale = cashRegister.PayWithPOS(cashRegister.GetPOS(), totalAmount, contactLessCard);
                        if (sale == true)
                        {
                            cashRegister.PrintPOSReceipt(totalAmount, contactLessCard);
                            cashRegister.PrintReceipt(totalAmount);
                        }
                    }
                    if (answer == 3)
                    {
                        sale = cashRegister.PayWithPOS(cashRegister.GetPOS(), totalAmount, phone);
                        if (sale == true)
                        {
                            cashRegister.PrintPOSReceipt(totalAmount, phone);
                            cashRegister.PrintReceipt(totalAmount);
                        }
                    }
                }
            }
            ///////////////////////////   END    ////////////////////////////////////////////


        }
    }
}
