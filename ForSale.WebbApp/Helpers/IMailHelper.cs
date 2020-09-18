using ForSale.ComunDll.Responses;
using System;


namespace ForSale.WebbApp.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string to, string subject, string body);

    }
}
