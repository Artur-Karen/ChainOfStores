using ChainOfStores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfStores.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        void Update(Employee obj);
        void Save();
    }
}
