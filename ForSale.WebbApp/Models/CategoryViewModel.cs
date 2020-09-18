using System;
using System.ComponentModel.DataAnnotations;
using ForSale.ComunDll.Entidades;
using Microsoft.AspNetCore.Http;

namespace ForSale.WebbApp.Models
{
    public class CategoryViewModel: Category
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
