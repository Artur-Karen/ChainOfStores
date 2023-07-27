using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChainOfStores.Models
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Base Salary")]
        public int BaseSalary { get; set; }
    }
}
