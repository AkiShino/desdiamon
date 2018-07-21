using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Foundation.Data.Model;

namespace Api.Foundation.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        UserDbEntities _dbContext;

        public UserDbEntities Init()
        {
            return _dbContext ?? (_dbContext = new UserDbEntities());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
            base.DisposeCore();
        }
    }
}
