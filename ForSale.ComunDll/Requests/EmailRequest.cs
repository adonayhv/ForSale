using System;
using System.ComponentModel.DataAnnotations;

namespace ForSale.ComunDll.Requests
{
    public class EmailRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
