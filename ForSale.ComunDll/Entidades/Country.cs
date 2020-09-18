using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ForSale.ComunDll.Entidades
{
    public class Country
    {
        
            public int Id { get; set; }

            [MaxLength(50)]
            [Required]
            public string Name { get; set; }

        public ICollection<Department> Departments  { get; set; }
        [DisplayName("Deparments Number")]
        public int DepartmentsNumber => Departments == null ? 0 : Departments.Count;


    }
}
