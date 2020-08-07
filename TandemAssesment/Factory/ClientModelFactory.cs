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
    public class ClientModelFactory : IClientUserFactory
    {
        private readonly IMapper _mapper;

        public ClientModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public UserViewModel Convert(UserModel user)
        {
            var model =  _mapper.Map<UserViewModel>(user);
            return model;
        } 
    }
}

