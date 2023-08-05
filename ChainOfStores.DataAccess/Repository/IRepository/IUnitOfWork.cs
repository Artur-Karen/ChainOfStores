using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfStores.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        IBakeryRepository Bakery { get; }
        IRoleRepository Role { get; }
        ISalaryRepository Salary { get; }
        IShopRepository Shop { get; }
        IStorageRepository Storage { get; }
        void Save();
    }
}
