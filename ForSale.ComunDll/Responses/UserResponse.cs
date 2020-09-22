using ForSale.ComunDll.Entidades;
using ForSale.ComunDll.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForSale.ComunDll.Responses
{
    public class UserResponse
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string ImageId { get; set; }

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
        public UserType UserType { get; set; }

        public City City { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";
    }


}
