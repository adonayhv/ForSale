using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSale.ComunDll.Entidades
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The filed {0} must contain less than {1} characteres.")]
        [Required]
        public string Name { get; set; }
      
        [Display(Name = "Image")]
        public string ImageId { get; set; }




        //  [Display(Name = "Image")]
        // public string ImageFullPath => ImageId == string.Empty
        //  ? $"https://adonayhv-001-site1.htempurl.com:8172/MsDeploy.axd?site=adonayhv-001-site1/images/noimage.png"
        //: $"https://adonayhv-001-site1.htempurl.com:8172/MsDeploy.axd?site=adonayhv-001-site1/{(ImageId.Substring(1))}";


        [Display(Name = "Image")]
      
       public string ImageFullPath
       {
            get
             {
                 if (string.IsNullOrEmpty(this.ImageId))
                {
                    //return "http://adonayhv-001-site1.htempurl.com/images/noimage.png";
                    return "http://forsaleon.azurewebsites.net/images/noimage.png";
                }
                 
                 //return $"http://adonayhv-001-site1.htempurl.com/{ImageId.Substring(1)}";
                return $"http://forsaleon.azurewebsites.net/{ImageId.Substring(1)}";
            }
        }
    }
}
