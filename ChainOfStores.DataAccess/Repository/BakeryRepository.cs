using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfStores.DataAccess.Repository
{
    public class BakeryRepository : Repository<Bakery>,IBakeryRepository
    {
        private ApplicationDbContext _db;
        public BakeryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Bakery obj)
        {
            _db.Bakeries.Add(obj);
        }
    }
}
