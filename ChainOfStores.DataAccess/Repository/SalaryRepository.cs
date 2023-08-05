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
    public class SalaryRepository:Repository<Salary>,ISalaryRepository
    {
        private readonly ApplicationDbContext _db;
        public SalaryRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Salary obj)
        {
            _db.Salaries.Update(obj);
        }
    }
}
