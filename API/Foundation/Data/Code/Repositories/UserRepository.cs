using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Api.Foundation.Data.Dtos;
using Api.Foundation.Data.Infrastructure;
using Api.Foundation.Data.Model;

namespace Api.Foundation.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private IDbFactory _dbFactory;

        public UserRepository()
        {
            _dbFactory = new DbFactory();
        }

        public bool IsExists(string email)
        {
            using (var dbContext = _dbFactory.Init())
            {
                var user = dbContext.M_User.DefaultIfEmpty(null).First(u => u.Email.Equals(email));
                return user != null;
            }
        }


        public bool EditUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(Expression<Func<UserDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserDto> GetAll()
        {
            using (var dbContext = _dbFactory.Init())
            {
                return dbContext.M_User.Select(u => new UserDto()
                {
                    UserID = u.UserID,
                    Email = u.Email,
                    FullName = u.FullName,
                    Password = u.Password,
                    Salt = u.Salt
                });

            }
        }

        public bool AddUser(UserDto user)
        {
            using (var dbContext = _dbFactory.Init())
            {
                var newUser = new M_User()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Password = user.Password,
                    Salt = user.Salt,
                    CreateDt = DateTime.Now,
                    UpdateDt = DateTime.Now,
                    ActivationCode = user.ActivationCode,
                    IsVerified = 0
                };
                try
                {
                    dbContext.M_User.Add(newUser);
                    dbContext.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public UserDto GetUser(string email)
        {
            using (var dbContext = _dbFactory.Init())
            {
                var user = dbContext.M_User.DefaultIfEmpty(null).First(u => u.Email.Equals(email));
                if (user != null)
                {
                    return new UserDto()
                    {
                        Email = user.Email,
                        FullName = user.FullName,
                        Password = user.Password,
                        Salt = user.Salt,
                        UserID = user.UserID
                    };
                }

                return null;
            }
        }

        public bool IsExistsUserWithActivationCode(string activationCode)
        {
            using (var dbContext = _dbFactory.Init())
            {
                var user = dbContext.M_User.DefaultIfEmpty(null).First(u => u.ActivationCode.Equals(activationCode));
                return user != null;
            }

        }

        public void VerifyUser(string activationCode)
        {
            using (var dbContext = _dbFactory.Init())
            {
                var user = dbContext.M_User.DefaultIfEmpty(null).First(u => u.ActivationCode.Equals(activationCode));
                user.IsVerified = 1;
                dbContext.SaveChanges();
            }
        }
    }
}
