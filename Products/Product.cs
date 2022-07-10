using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister.Products
{
    class Product
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

        public override string ToString()
        {
            return $"{nameOfProduct} {Price}";
        }
    }
}
