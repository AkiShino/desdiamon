using Api.Foundation.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Data.Infrastructure
{
   
    public class DbFactory : Disposable, IDbFactory
    {
        DesdiamonEntities dbContext;
        public DesdiamonEntities Init()
        {
            return dbContext ?? (dbContext = new DesdiamonEntities());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null) dbContext.Dispose();
        }
    }
}
