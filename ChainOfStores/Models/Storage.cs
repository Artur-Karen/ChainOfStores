using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChainOfStores.Models
{
    public class Storage
    {
        [Key]
        public int Id { get; set; }
        public int? ShopId { get; set; }
        [ForeignKey("ShopId")]
        public Shop? Shop { get; set; }
    }
}
