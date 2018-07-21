using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Foundation.Account;
using Api.Foundation.Account.Abstract;
using Api.Foundation.Data.Dtos;

namespace Api.Feature.Account.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IEncryptionService _encryptionService;

        public AccountController()
        {
            _userService = new UserService();
            _encryptionService = new EncryptionService();
        }

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(HttpRequestMessage request, [FromBody] UserDto user)
        {
            if (_userService.IsExistUser(user.Email))
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "User's already exists!");

            user.ActivationCode = _encryptionService.CreateActivationCode();
            if (_userService.CreateUser(user))
            {
                return Request.CreateResponse(HttpStatusCode.OK, user.ActivationCode);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error occur!");
        }

        [HttpGet]
        [Route("login")]
        public HttpResponseMessage Login(HttpRequestMessage request, [FromBody] UserDto user)
        {
            // TODO: Validate user and generate a access token
            return null;
        }

        [HttpPost]
        [Route("verify/generate")]
        public HttpResponseMessage GenerateConfirmEmail(HttpRequestMessage request, [FromBody] UserDto user)
        {
            //TODO: Send a confirm email contains activationCode to user
            return null;
        }

        [HttpPost]
        [Route("confirm")]
        public HttpResponseMessage ConfirmEmail(HttpRequestMessage request, string token)
        {
            if (_userService.VerifyUserIfExists(token))
                return Request.CreateResponse(HttpStatusCode.OK, true);

            return Request.CreateResponse(HttpStatusCode.NotFound, false);
        }

        [HttpPost]
        [Route("forgot")]
        public HttpResponseMessage ForgotPassword(HttpRequestMessage request)
        {
            return null;
        }



    }
}
