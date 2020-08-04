using Repository.Interface;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository : IRepository
    {
        public Task<bool> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetToUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
