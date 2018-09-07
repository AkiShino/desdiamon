using Api.Feature.Account.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Feature.Account.Infrastructure.Validators 
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            
            RuleFor(r => r.Email).NotEmpty()
                .WithMessage("Invalid email");

            RuleFor(r => r.Password).NotEmpty()
                .WithMessage("Invalid password");
        }
    }
    public class VerifyViewModelValidator : AbstractValidator<VerifyViewModel>
    {
        public VerifyViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(r => r.Email).NotEmpty()
                .WithMessage("Invalid Email");

            RuleFor(r => r.Token).NotEmpty()
                .WithMessage("Invalid token");
        }
    }

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(r => r.Email).NotEmpty()
                .WithMessage("Invalid username");

            RuleFor(r => r.Password).NotEmpty()
                .WithMessage("Invalid password");
        }
    }
}