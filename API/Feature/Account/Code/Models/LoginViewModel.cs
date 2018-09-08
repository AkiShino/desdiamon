using Api.Feature.Account.Infrastructure.Core;
using Api.Feature.Account.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api.Feature.Account.Models
{
    public class LoginViewModel: RequestBase, IValidatableObject
    {
        public LoginViewModel() : base(new LoginViewModelValidator())
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}