using Api.Foundation.Account.Abstract;
using Api.Foundation.Data.Model;
using Api.Foundation.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Dependencies;

namespace Api.Feature.Account.Infrastructure.Exxtensions
{
    public static class RequestMessageExtensions
    {
        internal static IMemberService GetMembershipService(this HttpRequestMessage request)
        {
            return request.GetService<IMemberService>();
        }

        internal static IEncryptionService GetEncryptionService(this HttpRequestMessage request)
        {
            return request.GetService<IEncryptionService>();
        }

        internal static IEntityBaseRepository<T> GetDataRepository<T>(this HttpRequestMessage request) where T : class, IEntityBase, new()
        {
            return request.GetService<IEntityBaseRepository<T>>();
        }

        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }
    }
}