using ChainOfStores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfStores.DataAccess.Repository.IRepository
{
    public interface IShopRepository:IRepository<Shop>
    {
        void Update(Shop obj);
    }
}
