using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Account.Abstract
{
    public interface IEncryptionService
    {
        string CreateActivationCode();
        string CreateSalt();
        string EncryptPassword(string password, string salt);
    }
}
