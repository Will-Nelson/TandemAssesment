using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TandemAssesment.Interface;
using TandemAssesment.Model;

namespace TandemAssesment.Service
{
    public class RepositoryService : IRepositoryService
    {

        private IRepository _repository;
        private IClientUserFactory _clientfactory;
        private IRepositoryUserFactory _userRepositoryFactory;
        public RepositoryService(IRepository repository, IClientUserFactory clientfactory, IRepositoryUserFactory repositoryFactory)
        {
            _repository = repository;
            _clientfactory = clientfactory;
            _userRepositoryFactory = repositoryFactory;
        }

        public async Task<bool> AddUserAsync(UserSaveModel user)
        {
            var usersave = _userRepositoryFactory.Convert(user);
            var result = await _repository.AddUser(usersave);
            return result;
        }

        public async Task<UserViewModel> GetUserAsync(string request)
        {
            var result  = await _repository.GetUser(request);
            var user = _clientfactory.Convert(result);
            return user;
        }
    }
}
