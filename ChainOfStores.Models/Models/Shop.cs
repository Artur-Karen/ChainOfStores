﻿using System.ComponentModel.DataAnnotations;

namespace ChainOfStores.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Bakery? Bakery { get; set; }
        public Storage? Storage { get; set; }
    }
}
