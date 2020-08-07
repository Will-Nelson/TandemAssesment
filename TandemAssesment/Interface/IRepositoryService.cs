using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TandemAssesment.Model;

namespace TandemAssesment.Interface
{
    public interface IRepositoryService
    {
        Task<bool> AddUserAsync(UserSaveModel item);
        Task<UserViewModel> GetUserAsync(string request);
        

    }
}
