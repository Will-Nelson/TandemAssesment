using Repository.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository
    {
        Task<UserModel> GetUser(string email);
        Task<bool> AddUser(UserModel user);
       
    }
}
