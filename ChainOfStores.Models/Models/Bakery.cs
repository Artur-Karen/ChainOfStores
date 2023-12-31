﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChainOfStores.Models
{
    public class Bakery
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public int? ShopId { get; set; }
        [ForeignKey("ShopId")]
        public Shop? Shop { get; set; }
    }
}
