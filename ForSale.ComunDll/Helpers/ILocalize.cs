using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ForSale.ComunDll.Helpers
{
  public  interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);

    }
}
