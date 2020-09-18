using System;
using System.ComponentModel.DataAnnotations;

namespace ForSale.ComunDll.Entidades
{
    public class ProductImage
    {
        public int Id { get; set; }

      
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

    }
}
