using AutoMapper;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TandemAssesment.Interface;
using TandemAssesment.Model;

namespace TandemAssesment.Factory
{
    public class RepositoryModelFactory : IRepositoryUserFactory
    {
        private readonly IMapper _mapper;

        public RepositoryModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserModel Convert(UserSaveModel user)
        {
            var model = _mapper.Map<UserModel>(user);
            return model;
        }
    }
}
