using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api.Feature.Account.Infrastructure.Core
{
    public abstract class RequestBase
    {
        private FluentValidation.IValidator _validator;

        public RequestBase(FluentValidation.IValidator validator)
        {
            _validator = validator;
        }

        #region Validator request
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = _validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
        #endregion
    }
}