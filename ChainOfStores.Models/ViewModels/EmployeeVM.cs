using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfStores.Models.ViewModels
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SalaryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ShopList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> StorageList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> BakeryList { get; set; }
    }
}
