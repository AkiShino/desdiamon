using Api.Feature.Account.Infrastructure.Core;
using Api.Feature.Account.Models;
using Api.Foundation.Account.Abstract;
using Api.Foundation.Account.Service;
using Api.Foundation.Account.Utilities;
using Api.Foundation.Data.Infrastructure;
using Api.Foundation.Data.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Api.Feature.Account.Controllers
{
    [System.Web.Http.AllowAnonymous]
  ///  [System.Web.Http.Route("api/Account")]
    public class SecurityController : ApiControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IEncryptionService _encryptionService;

        public SecurityController(IMemberService memberService, IEncryptionService encryptionService, IUnitOfWork _unitOfWork)
            : base(_unitOfWork)
        {
            _memberService = memberService;
            _encryptionService = encryptionService;
        }
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("authenticate")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {

                MembershipContext _userContext = _memberService.ValidateUser(user.Email, user.Password);

                if (_userContext.User != null)
                {
                    return request.CreateResponse(HttpStatusCode.OK, new
                    {
                        auth_key = _encryptionService.EncryptAuthorization(user.Email, user.Password),
                        fullName = _userContext.User.FullName,
                        userId = _userContext.User.Id
                    });
                }
                else
                {
                    throw new ApiResponseException("Login Fail");
                }
            });
        }

        [System.Web.Http.Route("api/Account/register")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request,[FromBody] RegistrationViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                if (_memberService.IsExistUser(user.Email))
                {
                    throw new ApiResponseException("User Exist");
                }
                else
                {
                    M_User _user = _memberService.CreateUser(user.Email, user.Password, user.FullName, user.Role);

                    return request.CreateResponse(HttpStatusCode.OK);

                }
            });
        }
    }
}