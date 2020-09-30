using ForSale.ComunDll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForSale.XamarinApp.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<PaymentMethod> GetPaymentMethods();
    }

}
