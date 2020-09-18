using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ForSale.WebbApp.Models
{
    public class AddProductImageViewModel
    {
       
            public int ProductId { get; set; }

            [Display(Name = "Image")]
            [Required]
            public IFormFile ImageFile { get; set; }
        }

    
}
