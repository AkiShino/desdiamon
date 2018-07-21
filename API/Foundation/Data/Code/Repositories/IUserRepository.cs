using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Api.Foundation.Data.Dtos;

namespace Api.Foundation.Data.Repositories
{
    public interface IUserRepository
    {
        bool IsExists(string email);
        bool EditUser(UserDto user);
        bool DeleteUser(UserDto user);
        bool DeleteUser(Expression<Func<UserDto, bool>> predicate);
        IQueryable<UserDto> GetAll();
        bool AddUser(UserDto user);
        UserDto GetUser(string email);
        bool IsExistsUserWithActivationCode(string activationCode);
        void VerifyUser(string activationCode);

    }
}
