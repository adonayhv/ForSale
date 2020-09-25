using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ForSale.ComunDll.Entidades
{
    public class City
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "City")]
        public string Name { get; set; }


        [JsonIgnore]
        [NotMapped]
        public int IdDepartment { get; set; }

        [JsonIgnore]
        public Department Department { get; set; }


    }
}
