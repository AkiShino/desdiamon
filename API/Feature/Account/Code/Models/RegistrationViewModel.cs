using Api.Feature.Account.Infrastructure.Core;
using Api.Feature.Account.Infrastructure.Validators;
using System.ComponentModel.DataAnnotations;

namespace Api.Feature.Account.Models
{
    public class RegistrationViewModel ///: RequestBase, IValidatableObject
    {
       //// public RegistrationViewModel() : base (new VerifyViewModelValidator())
       /// {
            
       /// }

        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
    public class ResetPasswordViewModel : RequestBase, IValidatableObject
    {
        public ResetPasswordViewModel()
            : base(new VerifyViewModelValidator())
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}