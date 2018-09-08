using Api.Foundation.Account.Abstract;
using Api.Foundation.Account.Utilities;
using Api.Foundation.Data.Infrastructure;
using Api.Foundation.Data.Model;
using Api.Foundation.Data.Repository;
using Api.Foundation.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Account.Service
{
   public class MemberService : IMemberService
    {
        private readonly IEntityBaseRepository<M_User> _userRepository;
        private readonly IEntityBaseRepository<T_Token> _tokenRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(IEntityBaseRepository<M_User> userRepository,
            IEntityBaseRepository<T_Token> tokenRepository,
            IEncryptionService encryptionService,
            IUnitOfWork unitOfWork
                      )
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }
        public MembershipContext ValidateUser(string email, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = _userRepository.GetSingleByEmail(email);
            if (user != null && isUserValid(user, password))
            {
                membershipCtx.User = user;
                var identity = new GenericIdentity(user.Id.ToString());
                membershipCtx.Principal = new GenericPrincipal(identity, new string[] { Constants.ADMIN_USER, Constants.NORMAL_USER });
            }

            return membershipCtx;
        }

        public bool IsExistUser(string email)
        {
            var existingUser = _userRepository.GetSingleByEmail(email);

            if (existingUser != null)
            {
                if (existingUser.IsVerified == 0)
                {
                    return true;
                }
                else
                {
                    _userRepository.Delete(existingUser);
                    _tokenRepository.DeleteToken(existingUser.Id, Constants.TOKEN_TYPE_REGIST);

                    _unitOfWork.Commit();
                }
            }
            return false;
        }

        public M_User CreateUser(string email, string password, string fullName, string userRole)
        {
            var passwordSalt = _encryptionService.CreateSalt();
          //  var id = _userRepository.GetAll();
            int userID = _userRepository.GetAll().Count() + 1;
            var user = new M_User()
            {
                UserID = userID,
                Email = email,
                FullName = fullName,
                Salt = passwordSalt,
                IsVerified = 0,
                UserRole = 2,
                Password = _encryptionService.EncryptPassword(password, passwordSalt),
                CreateDt = DateTime.Now,
                UpdateDt = DateTime.Now
            };

            _userRepository.Add(user);
            _unitOfWork.Commit();

            var token = new T_Token()
            {
                Id = userID,
                UserId = userID,
                Token = _encryptionService.CreateToken(),
                TokenType = Constants.TOKEN_TYPE_REGIST,
                ExpireDt = DateTime.Now.AddMinutes(Constants.EXPIRE_MINUTE)
            };

            _tokenRepository.Add(token);
            _unitOfWork.Commit();


            

                _unitOfWork.Commit();

            

            return user;
        }

        public M_User GetUser(string email)
        {
            return _userRepository.GetSingleByEmail(email);
        }

        public void ForgotPassword(M_User user)
        {
            double expireTime = Constants.EXPIRE_MINUTE;

            var token = new T_Token()
            {
                UserId = user.Id,
                Token = _encryptionService.CreateToken(),
                TokenType = Constants.TOKEN_TYPE_FORGOT,
                ExpireDt = DateTime.Now.AddMinutes(expireTime)
            };

            _tokenRepository.Add(token);
            _unitOfWork.Commit();
        }

        public void ChangePassword(M_User user, string password)
        {
           
        }

        public T_Token ValidateToken(int userId, string tokenType)
        {
            return _tokenRepository.GetToken(userId, tokenType);

        }

        public void VerifyUser(M_User user)
        {
        }
        
       

        #region Helper methods
        private bool isPasswordValid(M_User user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.Password);
        }

        private bool isUserValid(M_User user, string password)
        {
            if (isPasswordValid(user, password) && user.IsVerified == 1)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
