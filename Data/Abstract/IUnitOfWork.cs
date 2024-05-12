using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<Blog> Blogs { get; }
        IRepository<Service> Services { get; }
        IRepository<Solution> Solutions { get; }

        IRepository <Reference> References { get; }

        void Save();
    }
}
