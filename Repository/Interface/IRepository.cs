using Repository.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    interface IRepository
    {
        Task<IList<User>> GetToUsers();
        Task<bool> AddUser(User user);
        Task<bool> UpdateUser(User user);
    }
}
