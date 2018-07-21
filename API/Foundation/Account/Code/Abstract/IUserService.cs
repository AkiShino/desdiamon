using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Foundation.Data.Dtos;

namespace Api.Foundation.Account.Abstract
{
    public interface IUserService
    {
        bool IsExistUser(string email);
        bool CreateUser(UserDto user);
        void ForgotPassword(UserDto user);
        bool VerifyUserIfExists(string activationCode);
        bool ValidateUser(UserDto requestUser);
    }
}
