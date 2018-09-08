using Api.Foundation.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Account.Utilities
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public M_User User { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
