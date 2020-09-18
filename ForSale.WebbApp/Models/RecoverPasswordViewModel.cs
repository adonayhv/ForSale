using System;
using System.ComponentModel.DataAnnotations;

namespace ForSale.WebbApp.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


    }
}
