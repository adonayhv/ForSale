﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ForSale.ComunDll.Entidades
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public float Quantity { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public decimal Value => (decimal)Quantity * Price;

    }
}
