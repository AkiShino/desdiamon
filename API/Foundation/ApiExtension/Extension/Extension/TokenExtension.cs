using Api.Foundation.Data.Model;
using Api.Foundation.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Extension.Extension
{
    public static class TokenExtension
    {
        public static T_Token GetToken(this IEntityBaseRepository<T_Token> tokenRepository, int userId, string type)
        {

            var _token = tokenRepository.GetAll().Where(r => r.UserId == userId && r.TokenType == type).FirstOrDefault();

            return _token;
        }

        public static void DeleteToken(this IEntityBaseRepository<T_Token> tokenRepository, int userId, string type)
        {

            var _token = tokenRepository.GetAll().Where(r => r.UserId == userId && r.TokenType == type).FirstOrDefault();

            if (_token != null)
            {
                tokenRepository.Delete(_token);
            }
        }
    }
}
