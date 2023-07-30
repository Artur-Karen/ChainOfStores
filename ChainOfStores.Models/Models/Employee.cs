using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChainOfStores.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int? ShopId { get; set; }
        [ForeignKey("ShopId")]
        public Shop? Shop { get; set; }

        public int? BakeryId { get; set; }
        [ForeignKey("BakeryId")]
        public Bakery? Bakery { get; set; }

        public int? StorageId { get; set; }
        [ForeignKey("StorageId")]
        public Storage? Storage { get; set; }
        public int? SalaryId { get; set; }
        [ForeignKey("SalaryId")]
        public Salary? Salary { get; set; }
        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
    }
}
