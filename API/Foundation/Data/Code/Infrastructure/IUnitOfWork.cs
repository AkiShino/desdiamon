using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        DbContextTransaction BeginTransaction();
        DbContext GetContext();
    }
}
