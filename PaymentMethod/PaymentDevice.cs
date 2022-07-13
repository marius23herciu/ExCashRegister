using System;
using System.Collections.Generic;
using System.Text;

namespace ExCashRegister.PaymentMethod
{
    abstract class PaymentDevice
    {
        public bool availableForOperations = false;
        public double currentValue;
        /// <summary>
        /// Creates Payment Device.
        /// </summary>
        /// <param name="currentValue"></param>
        public PaymentDevice(double currentValue)
        {
            this.currentValue = currentValue;
        }
    }
}
