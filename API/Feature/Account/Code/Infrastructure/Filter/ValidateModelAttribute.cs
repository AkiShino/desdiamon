using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Metadata;
using System.Web.Http.Validation;

namespace Api.Feature.Account.Infrastructure.Filter
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var parametersWithNull = GetNonNullParametersWhichAreNull(actionContext);

            var argumentsWithNull = actionContext.ActionArguments.Where(
                 x => parametersWithNull.Any(
                     y => y.ParameterName == x.Key) && x.Value == null)
                     .ToList();

            // For each null-argument, create a default instance.
            foreach (var argument in argumentsWithNull)
            {
                var model = Activator.CreateInstance(parametersWithNull.First(x => x.ParameterName == argument.Key).ParameterType);
                actionContext.ActionArguments[argument.Key] = model;
                TryValidateModel(actionContext, model);
            }

            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest, new { message = "Invalid" });
            }
        }

        public class NonNullParameterWhichIsNull
        {
            public string ParameterName { get; set; }
            public Type ParameterType { get; set; }
        }

        /// <summary>
        /// Finds all action parameters which are null (non-nullable) and not
        /// simple types.
        /// </summary>
        protected IEnumerable<NonNullParameterWhichIsNull> GetNonNullParametersWhichAreNull(HttpActionContext context)
        {
            var parameters = context.ActionDescriptor.GetParameters()
                .Where(p => !p.IsOptional && p.DefaultValue == null &&
                    !p.ParameterType.IsValueType &&
                        p.ParameterType != typeof(string))
                 .Select(p => new NonNullParameterWhichIsNull
                 {
                     ParameterName = p.ParameterName,
                     ParameterType = p.ParameterType
                 })
                 .ToList();

            return parameters;
        }

        protected virtual bool TryValidateModel(HttpActionContext context, object model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            var metadataProvider = context.RequestContext.Configuration.Services.GetService(typeof(ModelMetadataProvider)) as ModelMetadataProvider;
            var validatorProviders = context.RequestContext.Configuration.Services.GetServices(typeof(ModelValidatorProvider)).Cast<ModelValidatorProvider>();
            var metadata = metadataProvider.GetMetadataForType(() => model, model.GetType());

            context.ModelState.Clear();
            var modelValidators = metadata.GetValidators(validatorProviders);
            foreach (var validationResult in modelValidators.SelectMany(v => v.Validate(metadata, null)))
            {
                context.ModelState.AddModelError(validationResult.MemberName, validationResult.Message);
            }

            return context.ModelState.IsValid;
        }

    }
}