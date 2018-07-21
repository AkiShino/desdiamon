using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Foundation.Data.Model;

namespace Api.Foundation.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        UserDbEntities Init();
    }
}
