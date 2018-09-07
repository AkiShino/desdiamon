using Api.Feature.Account.Infrastructure.Core;
using Api.Feature.Account.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api.Feature.Account.Models
{
    public class VerifyViewModel : RequestBase, IValidatableObject
    {
        public VerifyViewModel()
            : base(new VerifyViewModelValidator())
        {
        }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}