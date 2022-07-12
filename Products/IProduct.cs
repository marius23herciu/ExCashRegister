using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister.Products
{
    interface IProduct
    {
        string GetName();
        double GetPrice();
    }
}
