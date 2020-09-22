using System;
using System.ComponentModel.DataAnnotations;
using ForSale.ComunDll.Entidades;
using ForSale.ComunDll.Enums;
using Microsoft.AspNetCore.Identity;

namespace ForSale.WebbApp.Data.Entidades
{
    public class User: IdentityUser
    {
        [MaxLength(20)]
        [Required]
        public string Document { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Display(Name = "Image")]
        public string ImageId { get; set; }

        //  [Display(Name = "Image")]
        // public string ImageFullPath => ImageId == string.Empty
        //  ? $"https://localhost:4689/images/noimage.png"
        //: $"https://localhost:4689/{(ImageId.Substring(1))}";


        [Display(Name = "Image")]

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageId))
                {
                    return "http://forsaleon.azurewebsites.net/images/noimage.png";
                }

                return $"http://forsaleon.azurewebsites.net/{ImageId.Substring(1)}";
            }
        }
        [Display(Name = "User Type")]
        public UserType UserType { get; set; }

        public City City { get; set; }

        [Display(Name = "User")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "User")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

    }
}
