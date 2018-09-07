using Api.Foundation.Data.Model;
using Api.Foundation.Data.Repository;
using System.Linq;

namespace Extension.Extension
{
    public static class UserExtension
    {
        public static M_User GetSingleByEmail(this IEntityBaseRepository<M_User> userRepository, string email)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Email.ToUpper().Equals(email.ToUpper()));
        }

        public static M_User GetById (this IEntityBaseRepository<M_User> userRepository, int id)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
