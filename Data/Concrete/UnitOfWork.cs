using Data.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Blog> Blogs { get; private set; }

        public IRepository<Service> Services { get; private set; }

        public IRepository<Solution> Solutions { get; private set; }

        public IRepository<Reference> References { get; private set; }

        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Blogs=new  Repository<Blog>(_db);
            Services=new Repository<Service>(_db);
            Solutions=new Repository<Solution>(_db);    
            References=new Repository<Reference>(_db);  

        }

        public void Save()
        {
            _db.SaveChanges();  
        }
    }
}
