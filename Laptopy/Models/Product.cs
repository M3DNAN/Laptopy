﻿using System.ComponentModel.DataAnnotations;

namespace Laptopy.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Range(0, 5)]
        public int Rate { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<ProductImages> ProductImages { get; set; } = new List<ProductImages>();
        public string Model { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;
    }
}
