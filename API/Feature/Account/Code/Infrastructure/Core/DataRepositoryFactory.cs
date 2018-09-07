using Api.Feature.Account.Infrastructure.Exxtensions;
using Api.Foundation.Data.Model;
using Api.Foundation.Data.Repository;
using System.Net.Http;

namespace Api.Feature.Account.Infrastructure.Core
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        public IEntityBaseRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBase, new()
        {
            return request.GetDataRepository<T>();
        }
    }
    public interface IDataRepositoryFactory
    {
        IEntityBaseRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBase, new();
    }
}