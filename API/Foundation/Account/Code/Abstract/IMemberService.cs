using Api.Foundation.Account.Utilities;
using Api.Foundation.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Account.Abstract
{
    public interface IMemberService
    {
        MembershipContext ValidateUser(string email, string password);
        bool IsExistUser(string email);
        M_User CreateUser(string email, string password, string fullName, string userRole);
        M_User GetUser(string email);
        T_Token ValidateToken(int userId, string tokenType);
        void VerifyUser(M_User user);
        void ForgotPassword(M_User user);
        void ChangePassword(M_User user, string password);
       
    }
}
