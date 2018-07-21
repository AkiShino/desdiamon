using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Foundation.Account.Abstract;
using Api.Foundation.Data.Dtos;
using Api.Foundation.Data.Repositories;

namespace Api.Foundation.Account
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;

        public UserService()
        {
            _userRepository = new UserRepository();
            _encryptionService = new EncryptionService();
        }

        public bool IsExistUser(string email)
        {
            return _userRepository.IsExists(email);
        }

        public bool CreateUser(UserDto user)
        {
            string salt = _encryptionService.CreateSalt();
            user.Salt = salt;
            user.Password = _encryptionService.EncryptPassword(user.Password, salt);
            return _userRepository.AddUser(user);
        }

        public void ForgotPassword(UserDto user)
        {
            throw new NotImplementedException();
        }

        public bool VerifyUserIfExists(string activationCode)
        {
            if (_userRepository.IsExistsUserWithActivationCode(activationCode))
            {
                _userRepository.VerifyUser(activationCode);
                return true;
            }

            return false;
        }

        public bool ValidateUser(UserDto requestUser)
        {
            var user = _userRepository.GetUser(requestUser.Email);
            if (user != null && IsValidUser(user.Salt, user.Password, requestUser.Password))
                return true;
            return false;
        }


        public bool IsValidUser(string salt, string password, string realPassword)
        {
            return _encryptionService.EncryptPassword(realPassword, salt).Equals(password);
        }
    }
}
