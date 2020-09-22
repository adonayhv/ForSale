﻿using ForSale.ComunDll.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSale.ComunDll.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public bool IsStarred { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        public int ProductImagesNumber => ProductImages == null ? 0 : ProductImages.Count;

        public string ImageFullPath => ProductImages == null || ProductImages.Count == 0
            
         ? $"http://forsaleon.azurewebsites.net/images/noimage.png"
            : ProductImages.FirstOrDefault().ImageFullPath;

        public ICollection<QualificationResponse> Qualifications { get; set; }

        public int ProductQualifications => Qualifications == null ? 0 : Qualifications.Count;

        public float Qualification => Qualifications == null || Qualifications.Count == 0 ? 0 : Qualifications.Average(q => q.Score);
    }

}