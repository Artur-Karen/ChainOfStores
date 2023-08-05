using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfStores.DataAccess.Repository
{
    public class StorageRepository : Repository<Storage>,IStorageRepository
    {
        private readonly ApplicationDbContext _db;

        public StorageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Storage obj)
        {
            _db.Storages.Update(obj);
        }
    }
}
