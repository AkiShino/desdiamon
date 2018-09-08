using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Account.Abstract
{
    public interface IEncryptionService
    {
        string CreateToken();
        /// <summary>
        /// Creates a random salt
        /// </summary>
        /// <returns></returns>
        string CreateSalt();
        /// <summary>
        /// Generates a Hashed password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        string EncryptPassword(string password, string salt);
        /// <summary>
        /// EncryptAuthorization
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        string EncryptAuthorization(string email, string password);
        /// <summary>
        /// DecryptAuthorization
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string DecryptAuthorization(string text);
    }
}
