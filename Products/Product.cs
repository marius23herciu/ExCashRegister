using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister.Products
{
    class Product:IProduct
    {
        public string nameOfProduct;
        /// <summary>
        /// Creates product.
        /// </summary>
        /// <param name="nameOfProduct"></param>
        /// <param name="price"></param>
        public Product(string nameOfProduct, double price)
        {
            this.nameOfProduct = nameOfProduct;
            this.Price = price;
        }
        public double Price { get; private set; }

        public string GetName()
        {
            return this.nameOfProduct;
        }

        public double GetPrice()
        {
            return this.Price;
        }

        public override string ToString()
        {
            return $"{GetName()} {GetPrice()}";
        }
    }
}
