using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfStores.DataAccess.Repository
{
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        private readonly ApplicationDbContext _db;
        public ShopRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Shop obj)
        {
            _db.Shops.Update(obj);
        }
    }
}
