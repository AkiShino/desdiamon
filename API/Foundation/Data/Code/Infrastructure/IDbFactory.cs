using Api.Foundation.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DesdiamonEntities Init();
    }
}
